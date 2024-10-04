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
    public class UpdateUserDTOValidator : UserBaseValidator<UpdateUserDto>
    {
        public UpdateUserDTOValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).NotEmpty()
                               .WithMessage("Id is required.")
                               .Must(x => ctx.Users.Any(c => c.Id == x))
                               .WithMessage("User not exist");

            RuleFor(x => x.Password).Matches("^(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9]).{8,}$")
               .WithMessage("The password must contain at least 8 characters and must contain at least one capital letter, one number and one special character.");
        }
    }
}
