using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.PersonalTraining;
using Gym.Application.DTO.Status;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Status
{
    public class DeleteStatusDTOValidator : AbstractValidator<BaseStatusDTO>
    {
        public DeleteStatusDTOValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).Must(x => ctx.Status.Any(u => u.Id == x))
                .WithMessage("Id must exists");

        }
    }
}
