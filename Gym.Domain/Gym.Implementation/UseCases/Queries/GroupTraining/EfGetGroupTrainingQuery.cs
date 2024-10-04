using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;
using Gym.Domain;

namespace Gym.Implementation.UseCases.Queries.GroupTraining
{
    public class EfGetGroupTrainingQuery : EfFindUseCase<ResponseGroupTrainingDTO, Domain.GroupTraining>, IGetGroupTrainingQuery
    {
        public EfGetGroupTrainingQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id => 15;

        public override string Name => "GroupTraining Search";
    }
}
