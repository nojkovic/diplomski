using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.MembershipFee;
using Gym.Application.DTO.Status;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Status
{
    public class StatusBaseValidator<T> : AbstractValidator<T>
        where T : BaseStatusDTO
    {
        

        public StatusBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                .NotEmpty()
                .Matches("^[A-ZŠĐČĆŽ][a-zšđčćžA-ZŠĐČĆŽ]{2,39}(\\s[a-zšđčćžA-ZŠĐČĆŽ]{2,39})*$")
                .WithMessage("Name must have 3 character. ");



        }

        
    }
}
