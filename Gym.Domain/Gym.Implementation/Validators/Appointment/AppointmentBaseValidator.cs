using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.GroupTraining;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Appointment
{
    public class AppointmentBaseValidator<T> : AbstractValidator<T>
        where T : BaseAppointmentDTO
    {
        public AppointmentBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Date)
               .NotEmpty();
            RuleFor(x => x.CoachTrainingId).Must(x => ctx.CoachTrainings.Any(u => u.Id == x))
                .WithMessage("CoachTrainingId must exists").NotEmpty();
            RuleFor(x => x.GymId).Must(x => ctx.Gyms.Any(u => u.Id == x))
               .WithMessage("GymId must exists").NotEmpty();
            RuleFor(x => x.Time).NotEmpty();


        }
        
    }
}
