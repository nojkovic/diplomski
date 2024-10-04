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
    public class UpdateMembershipFeeDTOValidator : MembershipFeeBaseValidator<UpdateMembershipFeeDTO>
    {
        public UpdateMembershipFeeDTOValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.MembershipFees.Any(u => u.Id == x))
              .WithMessage("Id must exists");
        }
    }
}
