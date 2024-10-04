using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.MembershipFee;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.MembershipFee
{
    public class AddMembershipFeeDTOValidator : MembershipFeeBaseValidator<MembershipFeeDTO>
    {
        public AddMembershipFeeDTOValidator(GymContext ctx) : base(ctx)
        {
        }
    }
}
