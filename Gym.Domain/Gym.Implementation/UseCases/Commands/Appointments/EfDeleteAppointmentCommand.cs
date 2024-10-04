using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Appointment;
using Gym.Application.UseCases.Commands.Appointments;
using Gym.DataAccess;
using Gym.Implementation.Validators.Appointment;
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.Appointments
{
    public class EfDeleteAppointmentCommand : EfUseCase, IDeleteAppointmentCommand
    {
        private DeleteAppointmentDTOValidator validator;
        public EfDeleteAppointmentCommand(GymContext context, DeleteAppointmentDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 54;

        public string Name =>"Appointment Delete";

        public void Execute(BaseAppointmentDTO data)
        {
            validator.ValidateAndThrow(data);
            Domain.Appointment ap = Context.Appointments.Include(x => x.Reservations)
                                            .First(x => x.Id == data.Id);

            var appointmentReservation = ap.Reservations;

            foreach (var r in appointmentReservation)
            {
                r.IsActive = false;

            }
          
            ap.IsActive = false;
            Context.SaveChanges();
        }
    }
}
