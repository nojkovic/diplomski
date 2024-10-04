using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.DTO.GymTraining;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.GymTraining
{
    public class GymTrainingBaseValidator<T> : AbstractValidator<T>
        where T : BaseGymTrainingDTO
    {
        
        public GymTrainingBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;


            RuleFor(x => x.TrainingId).Must(x => ctx.Trainings.Any(u => u.Id == x))
               .WithMessage("TrainingId must exists").NotEmpty();

            RuleFor(x => x.GymId).Must(x => ctx.Gyms.Any(u => u.Id == x))
              .WithMessage("GymId must exists").NotEmpty();


        }
       
    }
}
