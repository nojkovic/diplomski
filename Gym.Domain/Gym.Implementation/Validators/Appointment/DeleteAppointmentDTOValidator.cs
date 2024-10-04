using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.Coach;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Appointment
{
    public class DeleteAppointmentDTOValidator : AbstractValidator<BaseAppointmentDTO>
    {
        public DeleteAppointmentDTOValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).Must(x => ctx.Appointments.Any(u => u.Id == x))
                .WithMessage("Id must exists");

        }
    }
}
