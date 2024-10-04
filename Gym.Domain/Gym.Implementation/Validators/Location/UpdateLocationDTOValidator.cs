using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Location;
using Gym.Application.DTO.MembershipFee;
using Gym.DataAccess;
using Gym.Implementation.Validators.MembershipFee;

namespace Gym.Implementation.Validators.Location
{
    public class UpdateLocationDTOValidator : LocationBaseValidator<UpdateLocationDTO>
    {
        public UpdateLocationDTOValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.Locations.Any(u => u.Id == x))
              .WithMessage("Id must exists");
        }
    }
}
