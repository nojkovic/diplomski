using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.CoachTraining
{
    public class EfGetCoachTrainingQuery : EfFindUseCase<ResponseCoachTrainingDTO, Domain.CoachTraining>, IGetCoachTrainingQuery
    {
        public EfGetCoachTrainingQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id => 50;

        public override string Name => "CoachTraining Search";
    }
}
