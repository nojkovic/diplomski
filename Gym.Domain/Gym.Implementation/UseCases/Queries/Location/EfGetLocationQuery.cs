using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Location;
using Gym.Application.DTO.MembershipFee;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Location
{
    public class EfGetLocationQuery : EfFindUseCase<ResponseLocationDTO, Domain.Location>, IGetLocationQuery
    {
        public EfGetLocationQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id => 25;

        public override string Name => "Location Search";
    }
}
