using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.Training;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.CoachTraining
{
    public class CoachTrainingBaseValidator<T> : AbstractValidator<T>
        where T : BaseCoachTrainingDTO
    {
        public CoachTrainingBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

           
            RuleFor(x => x.CoachId).Must(x => ctx.Coachs.Any(u => u.Id == x))
               .WithMessage("CoachId must exists").NotEmpty();
            RuleFor(x => x.TrainingId).Must(x => ctx.Trainings.Any(u => u.Id == x))
               .WithMessage("TrainingId must exists").NotEmpty();

            RuleFor(x => x.GymId).Must(x => ctx.Gyms.Any(u => u.Id == x))
              .WithMessage("GymId must exists").NotEmpty();

        }

       
    }
}
