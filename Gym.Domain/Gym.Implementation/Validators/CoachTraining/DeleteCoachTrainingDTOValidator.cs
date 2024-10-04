using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.Status;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.CoachTraining
{
    public class DeleteCoachTrainingDTOValidator : AbstractValidator<BaseCoachTrainingDTO>
    {
        public DeleteCoachTrainingDTOValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).Must(x => ctx.CoachTrainings.Any(u => u.Id == x))
                .WithMessage("Id must exists");

        }
    }
}
