using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.User;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Users
{
    public class DeleteUserDTOValidator : AbstractValidator<BaseUserDto>
    {
        public DeleteUserDTOValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).Must(x => ctx.Users.Any(u => u.Id == x))
                .WithMessage("Id must exists");
        }
    }
}
