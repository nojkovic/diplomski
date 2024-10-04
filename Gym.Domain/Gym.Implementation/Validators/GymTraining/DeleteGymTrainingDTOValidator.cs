using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.GymTraining;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.GymTraining
{
    public class DeleteGymTrainingDTOValidator:AbstractValidator<BaseGymTrainingDTO>
    {
        public DeleteGymTrainingDTOValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).Must(x => ctx.GymTrainings.Any(u => u.Id == x))
                .WithMessage("Id must exists");

        }
    }
}
