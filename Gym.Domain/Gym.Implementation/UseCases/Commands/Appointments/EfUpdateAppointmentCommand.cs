using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Appointment;
using Gym.Application.UseCases.Commands.Appointments;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.Appointment;

namespace Gym.Implementation.UseCases.Commands.Appointments
{
    public class EfUpdateAppointmentCommand : EfUseCase, IUpdateAppointmentCommand
    {
        private UpdateAppointmentDTOValidator validator;
        public EfUpdateAppointmentCommand(GymContext context, UpdateAppointmentDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 53;

        public string Name => "Appointment Update";

        public void Execute(UpdateAppointmentDTO data)
        {
            validator.ValidateAndThrow(data);
            Appointment ap = Context.Appointments.First(x => x.Id == data.Id);
            ap.CoachTrainingId = data.CoachTrainingId;
            ap.GymId = data.GymId;
            ap.Date = data.Date;
            ap.Time = data.Time;
            ap.IsActive = true;


            Context.SaveChanges();
        }
    }
}
