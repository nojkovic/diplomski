using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application;
using Gym.Application.DTO.Email;
using Gym.Application.DTO.Reservation;
using Gym.Application.Email;
using Gym.Application.UseCases.Commands.Reservations;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.Reservation;
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.Reservations
{
    public class EfAddReservationCommand : EfUseCase, IAddReservationCommand
    {
        private AddReservationDTOValidator validator;
        private IApplicationActor actor;
        private IEmailSender emailSender;
        public EfAddReservationCommand(GymContext context, AddReservationDTOValidator validator, IEmailSender emailSender, IApplicationActor actor) : base(context)
        {
            this.validator = validator;
            this.emailSender = emailSender;
            this.actor = actor;
        }

        public int Id => 62;

        public string Name => "Reservation Add";

        public void Execute(ReservationDTO data)
        {
            validator.ValidateAndThrow(data);

            if (data.UserId != actor.Id)
            {
                throw new UnauthorizedAccessException("You don't have privileges to make a reservation for another user.");
            }

            var gym = Context.Gyms
                .Include(g => g.Location)
                .FirstOrDefault(x => x.Id == data.GymId);

            var appointment = Context.Appointments
                .Include(a => a.CoachTraining)
                .ThenInclude(ct => ct.Training)
                .Include(a => a.CoachTraining)
                .ThenInclude(ct=>ct.Coach)
                .FirstOrDefault(x => x.Id == data.AppointmentId);

            var statusId = Context.Status
                .Where(x => x.Name == "Processing")
                .Select(x => x.Id)
                .FirstOrDefault();

            if (gym != null && appointment != null)
            {
                Reservation r = new Reservation
                {
                    UserId = data.UserId,
                    GymId = data.GymId,
                    CoachId = data.CoachId,
                    AppointmentId = data.AppointmentId,
                    StatusId = statusId
                };

                Context.Reservations.Add(r);
                Context.SaveChanges();

               
            }
                var body = "Well done, you have successfully created a reservation.\nThe current status of the reservation is in process, if there are any changes, you will be informed in a timely manner.";
                body += $"<br><br>Gym: {gym.Location.Address}/{gym.Location.City}";
                body += $"<br><br>Coach: {appointment.CoachTraining.Coach.Name}   {appointment.CoachTraining.Coach.LastName}";
                body += $"<br><br>Appointment Date: {appointment.Date}";
                body += $"<br><br>Appointment Time: {appointment.Time}";
                body += $"<br><br>Training: {appointment.CoachTraining.Training.TrainingType}";

            EmailDTO dto = new EmailDTO
            {
                Subject = "Reservation",
                SendTo = Context.Users.Where(x=>x.Id==data.UserId).Select(c=>c.Email).FirstOrDefault(),
                Body = body,
               
            };

            emailSender.SendEmail(dto);
        }
    }
}
