using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Status;
using Gym.Application.DTO.Training;
using Gym.DataAccess;
using Gym.Implementation.Validators.Status;

namespace Gym.Implementation.Validators.Training
{
    public class UpdateTrainingDTOValidator : TrainingBaseValidator<UpdateTrainingDTO>
    {
        public UpdateTrainingDTOValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.Trainings.Any(u => u.Id == x))
             .WithMessage("Id must exists");
        }
    }
}
