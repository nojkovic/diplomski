using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.MembershipFee;
using Gym.Application.DTO.Status;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Status
{
    public class EfGetStatusIdQuery : EfFindUseCase<ResponseStatusDTO, Domain.Status>, IGetStatusIdQuery
    {
        public EfGetStatusIdQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id =>30;

        public override string Name => "StatusId Search";
    }
}
