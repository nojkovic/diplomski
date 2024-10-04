using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Status;
using Gym.Application.DTO.Training;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Training
{
    public class TrainingBaseValidator<T> : AbstractValidator<T>
        where T : BaseTrainingDTO
    {
       

        public TrainingBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.TrainingType)
                .NotEmpty().Matches("^.{2,39}$")
                .WithMessage("Training type must have 3 character. ");


        }

        
    }
}
