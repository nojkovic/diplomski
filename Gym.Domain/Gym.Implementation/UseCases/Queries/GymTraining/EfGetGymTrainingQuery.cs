using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.GymTraining;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.GymTraining
{
    public class EfGetGymTrainingQuery : EfFindUseCase<ResponseGymTrainingDTO, Domain.CoachTraining>, IGetGymTrainingQuery
    {
        public EfGetGymTrainingQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id => 79;

        public override string Name => "Gym training search by id";
    }
}
