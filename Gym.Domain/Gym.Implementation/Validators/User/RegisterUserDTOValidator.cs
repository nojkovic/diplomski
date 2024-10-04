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
    public class RegisterUserDtoValidator : UserBaseValidator<RegisterUserDTO>
    {
        public RegisterUserDtoValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Contact).NotEmpty();

            RuleFor(x => x.Password).Matches("^(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9]).{8,}$")
               .WithMessage("The password must contain at least 8 characters and must contain at least one capital letter, one number and one special character.");

        }
    }
}
