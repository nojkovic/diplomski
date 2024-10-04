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
    public class EfUpdateReservationCommand : EfUseCase, IUpdateReservationCommand
    {
        private UpdateReservationDTOValidator validator;
        private IApplicationActor actor;
        private IEmailSender emailSender;
        public EfUpdateReservationCommand(GymContext context, UpdateReservationDTOValidator validator, IEmailSender emailSender, IApplicationActor actor) : base(context)
        {
            this.validator = validator;
            this.emailSender = emailSender;
            this.actor = actor;
        }

        public int Id => 63;

        public string Name => "Reservation Update";

        public void Execute(UpdateReservationDTO data)
        {
            validator.ValidateAndThrow(data);
            if (data.UserId != actor.Id)
            {
                throw new UnauthorizedAccessException("You don't have privileges to make this action.");
            }

            var gym = Context.Gyms
                .Include(g => g.Location)
                .FirstOrDefault(x => x.Id == data.GymId);

            var appointment = Context.Appointments
                .Include(a => a.CoachTraining)
                .ThenInclude(ct => ct.Training)
                .Include(a => a.CoachTraining)
                .ThenInclude(ct => ct.Coach)
                .FirstOrDefault(x => x.Id == data.AppointmentId);


            Reservation r = Context.Reservations.FirstOrDefault(x => x.Id == data.Id);
            r.UserId = data.UserId;
            r.GymId = data.GymId;
            r.CoachId = data.CoachId;
            r.AppointmentId = data.AppointmentId;
            r.StatusId = data.StatusId;
            r.IsActive = true;

            var statusName = Context.Status
            .Where(x => x.Id == r.StatusId)
            .Select(x => x.Name)
            .FirstOrDefault();
            Context.SaveChanges();
            var body="";
            if (statusName== "Refuse")
            {
                body = "Your reservation has been rejected, for more information call +381655491086";
               
            }
            else if(statusName == "Confirmed") 
            {
                body = "Congratulations, your reservation has been successfully created and accepted by the administrator.\r\nReservation details:";
                body += $"<br><br>Gym: {gym.Location.Address}/{gym.Location.City}";
                body += $"<br><br>Coach: {appointment.CoachTraining.Coach.Name}   {appointment.CoachTraining.Coach.LastName}";
                body += $"<br><br>Appointment Date: {appointment.Date}";
                body += $"<br><br>Appointment Time: {appointment.Time}";
                body += $"<br><br>Training: {appointment.CoachTraining.Training.TrainingType}";
            }
            
           
            EmailDTO dto = new EmailDTO
            {
                SendTo = Context.Users.Where(x => x.Id == data.UserId).Select(c => c.Email).FirstOrDefault(),
                Body = body,
                Subject = statusName
            };

            emailSender.SendEmail(dto);
            
        }
    }
}
