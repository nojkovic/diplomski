using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Photo;
using Gym.DataAccess;
using Gym.Implementation.Validators.Photo;

namespace Gym.Implementation.Validators.Coach
{
    public class UpdateCoachDTOValidator : CoachBaseValidator<UpdateCoachDTO>
    {
        public UpdateCoachDTOValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.Coachs.Any(u => u.Id == x))
                .WithMessage("Id must exists");
        }
    }
}
