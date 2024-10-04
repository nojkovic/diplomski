using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Gym;
using Gym.Application.DTO.Location;
using Gym.DataAccess;
using Gym.Implementation.Validators.Location;

namespace Gym.Implementation.Validators.Gym
{
    public class AddGymDTOValidator : GymBaseValidator<GymDTO>
    {
        public AddGymDTOValidator(GymContext ctx) : base(ctx)
        {
        }
    }
}
