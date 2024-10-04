using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.PersonalTraining;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.PersonalTraining
{
    public class UpdatePersonalTrainingDTOValidator : PersonalTrainingBaseValidator<UpdatePersonalTrainingDTO>
    {
        public UpdatePersonalTrainingDTOValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.PersonalTrainings.Any(u => u.Id == x))
             .WithMessage("Id must exists");
        }
    }
}
