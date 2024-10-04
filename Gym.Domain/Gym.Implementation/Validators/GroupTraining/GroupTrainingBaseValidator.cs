using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.GroupTraining;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.GroupTraining
{
    public class GroupTrainingBaseValidator<T> : AbstractValidator<T>
        where T : BaseGroupTrainingDTO
    {


        public GroupTrainingBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.TypeOfTraining)
               .NotEmpty()
              .Matches("^.{2,39}$")
                .WithMessage("Training type must have 3 character. ");

            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.PricePerTerm).NotEmpty().GreaterThan(0);


        }
    }
       
}
