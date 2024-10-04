using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Location;
using Gym.Application.DTO.MembershipFee;
using Gym.DataAccess;
using Gym.Implementation.Validators.MembershipFee;

namespace Gym.Implementation.Validators.Location
{
    public class AddLocationDTOValidator : LocationBaseValidator<LocationDTO>
    {
        public AddLocationDTOValidator(GymContext ctx) : base(ctx)
        {
        }
    }
}

