using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application;
using Gym.Application.DTO.Email;
using Gym.Application.DTO.Reservation;
using Gym.Application.Email;
using Gym.Application.UseCases.Commands.Reservations;
using Gym.Application.UseCases.Commands.Users;
using Gym.DataAccess;
using Gym.Domain;
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.Reservations
{
    public class EfModifyStatusCommand : EfUseCase, IModifyStatusCommand
    {
        private IApplicationActor actor;
        private IEmailSender emailSender;
        public EfModifyStatusCommand(GymContext context, IApplicationActor actor, IEmailSender emailSender) : base(context)
        {
            this.actor = actor;
            this.emailSender = emailSender;
        }

        public int Id =>74;

        public string Name => "Modify status";

        public void Execute(ReservationUpdatePatch data)
        {
            Reservation res = Context.Reservations.First(x => x.Id == data.Id);

            if (data.StatusId.HasValue)
            {
                res.StatusId = data.StatusId.Value;
            }

            Context.SaveChanges();

            var updatedReservation = Context.Reservations
           .Include(r => r.Gym)
           .Include(r => r.Coach)
           .Include(r => r.Appointment)
           .ThenInclude(a => a.CoachTraining)
           .ThenInclude(ct => ct.Training)
           .FirstOrDefault(x => x.Id == data.Id);

            var statusName = Context.Status
                .Where(x => x.Id == res.StatusId)
                .Select(x => x.Name)
                .FirstOrDefault();

            var body = "";

            if (statusName == "Refuse")
            {
                body = "Your reservation has been rejected, for more information call +381655491086";
            }
            else if (statusName == "Confirmed")
            {
                body = "Congratulations, your reservation has been successfully created and accepted by the administrator.\r\nReservation details:";
                body += $"<br><br>Gym: {updatedReservation.Gym.Location.Address}/{updatedReservation.Gym.Location.City}";
                body += $"<br><br>Coach: {updatedReservation.Coach.Name} {updatedReservation.Coach.LastName}";
                body += $"<br><br>Appointment Date: {updatedReservation.Appointment.Date}";
                body += $"<br><br>Appointment Time: {updatedReservation.Appointment.Time}";
                body += $"<br><br>Training: {updatedReservation.Appointment.CoachTraining.Training.TrainingType}";
            }

            EmailDTO dto = new EmailDTO
            {
                SendTo = Context.Users.Where(x => x.Id == res.UserId).Select(c => c.Email).FirstOrDefault(),
                Body = body,
                Subject = statusName
            };

            emailSender.SendEmail(dto);
        }
    }
}
