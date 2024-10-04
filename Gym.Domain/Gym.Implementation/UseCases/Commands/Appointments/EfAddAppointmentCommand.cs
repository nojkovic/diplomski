using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Appointment;
using Gym.Application.UseCases.Commands.Appointments;
using Gym.Application.UseCases.Commands.Coach;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.Appointment;

namespace Gym.Implementation.UseCases.Commands.Appointments
{
    public class EfAddAppointmentCommand : EfUseCase, IAddAppointmentCommand
    {
        private AddAppointmentDTOValidator validator;
        public EfAddAppointmentCommand(GymContext context, AddAppointmentDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 52;

        public string Name => "Appointment Add";

        public void Execute(AppointmentDTO data)
        {
            validator.ValidateAndThrow(data);

            Appointment ap = new Appointment
            {
                CoachTrainingId = data.CoachTrainingId,
                GymId = data.GymId,
                Date = data.Date,
                Time = data.Time,

            };

            Context.Appointments.Add(ap);
            Context.SaveChanges();
        }
    }
}
