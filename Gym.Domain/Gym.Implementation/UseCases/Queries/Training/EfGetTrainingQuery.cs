using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Status;
using Gym.Application.DTO.Training;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Training
{
    public class EfGetTrainingQuery : EfFindUseCase<ResponseTrainingDTO, Domain.Training>, IGetTrainingQuery
    {
        public EfGetTrainingQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id => 45;

        public override string Name => "Training Search";
    }
}
