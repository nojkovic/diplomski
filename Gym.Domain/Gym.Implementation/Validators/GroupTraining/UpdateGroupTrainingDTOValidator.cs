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
    public class UpdateGroupTrainingDTOValidator : GroupTrainingBaseValidator<UpdateGroupTrainingDTO>
    {
        public UpdateGroupTrainingDTOValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.GroupTrainings.Any(u => u.Id == x))
              .WithMessage("Id must exists");
        }
    }
}
