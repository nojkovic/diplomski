using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.Coach;
using Gym.DataAccess;
using Gym.Implementation.Validators.Coach;

namespace Gym.Implementation.Validators.Appointment
{
    public class UpdateAppointmentDTOValidator : AppointmentBaseValidator<UpdateAppointmentDTO>
    {
        public UpdateAppointmentDTOValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.Appointments.Any(u => u.Id == x))
                .WithMessage("Id must exists");
        }
    }
}
