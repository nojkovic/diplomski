using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Gym;
using Gym.Application.DTO.Location;
using Gym.DataAccess;
using Gym.Implementation.Validators.Location;

namespace Gym.Implementation.Validators.Gym
{
    public class UpdateGymDTOValidator : GymBaseValidator<UpdateGymDTO>
    {
        public UpdateGymDTOValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.Gyms.Any(u => u.Id == x))
              .WithMessage("Id must exists");
        }
    }
}
