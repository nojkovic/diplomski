using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.DTO.Gym;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Gym
{
    public class EfGetGymQuery : EfFindUseCase<ResponseGymDTO, Domain.Gym>, IGetGymQuery
    {
        public EfGetGymQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id => 60;

        public override string Name => "Gym Search";
    }
}
