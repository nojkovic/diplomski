using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.GymTraining;
using Gym.DataAccess;
using Gym.Implementation.Validators.CoachTraining;

namespace Gym.Implementation.Validators.GymTraining
{
    public class UpdateGymTrainingDTOValidator : GymTrainingBaseValidator<UpdateGymTrainingDTO>
    {
        public UpdateGymTrainingDTOValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.GymTrainings.Any(u => u.Id == x))
             .WithMessage("Id must exists");
        }
    }
}
