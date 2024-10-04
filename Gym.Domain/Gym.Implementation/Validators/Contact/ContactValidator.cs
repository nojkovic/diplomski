using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Contact;
using Gym.Application.DTO.User;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Contact
{
    public class ContactValidator : AbstractValidator<ContactDTO>
    {
        public ContactValidator(GymContext ctx) {
            RuleFor(x => x.Email)
                   .EmailAddress()
                   .WithMessage("Email must be in valid format.");
        }

    }
}
