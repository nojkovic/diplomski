using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.MembershipFee;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;
using Gym.Domain;

namespace Gym.Implementation.UseCases.Queries.MembershipFee
{
    public class EfGetMembershipFeeQuery : EfFindUseCase<ResponseMembershipFeeDTO, Domain.MembershipFee>, IGetMembershipFeeQuery
    {
        public EfGetMembershipFeeQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id => 10;

        public override string Name => "MembershipFee Search";
    }
}
