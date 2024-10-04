using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Gym;
using Gym.Application.DTO.Location;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Gym
{
    public class GymBaseValidator<T> : AbstractValidator<T>
        where T : BaseGymDTO
    {
        public GymBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Contact)
               .Matches("^\\+?[0-9]{1,15}$")
                .WithMessage("The contact should look like this, for example +381658496124");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.WorkingTime).NotEmpty();
            RuleFor(x => x.WorkingTimeOnWeekend).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            //RuleFor(x => x.LocationId).Must(x => ctx.Locations.Any(u => u.Id == x))
            //    .WithMessage("LocationId must exists").NotEmpty();



        }
       
    }
}
