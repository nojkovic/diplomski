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
    public class UserBaseValidator<T> : AbstractValidator<T>
        where T : BaseUserDto
    {
        public UserBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
                .EmailAddress()
                .Must(x => !ctx.Users.Any(u => u.Email == x))
                .WithMessage("Email is already in use.");
            RuleFor(x => x.Name).Matches("^[A-Z][a-zA-Z]{2,14}$")
                .WithMessage("The first character or letter must be uppercase, the minimum length is 3 and the maximum is 15 characters.");
            RuleFor(x => x.LastName).Matches("^[A-Z][a-zA-Z]{2,14}$")
                .WithMessage("The first character or letter must be uppercase, the minimum length is 3 and the maximum is 15 characters.");
            RuleFor(x => x.Contact)
                .Matches("^\\+?[0-9]{1,15}$")
                .WithMessage("The contact should look like this, for example +381658496124");



        }
    }
}
