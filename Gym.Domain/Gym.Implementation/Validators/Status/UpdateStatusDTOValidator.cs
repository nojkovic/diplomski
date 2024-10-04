using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.PersonalTraining;
using Gym.Application.DTO.Status;
using Gym.DataAccess;
using Gym.Implementation.Validators.PersonalTraining;

namespace Gym.Implementation.Validators.Status
{
    public class UpdateStatusDTOValidator : StatusBaseValidator<UpdateStatusDTO>
    {
        public UpdateStatusDTOValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.Status.Any(u => u.Id == x))
             .WithMessage("Id must exists");
        }
    }
}
