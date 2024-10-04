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
    public class DeleteGroupTrainingDTOValidator : AbstractValidator<BaseGroupTrainingDTO>
    {
        public DeleteGroupTrainingDTOValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).Must(x => ctx.GroupTrainings.Any(u => u.Id == x))
                .WithMessage("Id must exists");

        }
    }
}
