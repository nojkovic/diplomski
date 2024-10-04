using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Location;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Coach
{
    public class EfGetCoachQuery : EfFindUseCase<ResponseCoachDTO, Domain.Coach>, IGetCoachQuery
    {
        public EfGetCoachQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id =>40;

        public override string Name => "Coach Search";
    }
}
