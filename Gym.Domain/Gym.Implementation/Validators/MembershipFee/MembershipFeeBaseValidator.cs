using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.MembershipFee;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.MembershipFee
{
    public class MembershipFeeBaseValidator<T> : AbstractValidator<T>
        where T : BaseMembershipFeeDTO
    {
       
        public MembershipFeeBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.TypeOfMembership)
                .NotEmpty().Matches("^.{2,39}$")
                .WithMessage("Membership type must have 3 character. ");


            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x=>x.Price).NotEmpty().GreaterThan(0);
        }

       
    }
}
