using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.PersonalTraining;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;
using Gym.Domain;

namespace Gym.Implementation.UseCases.Queries.PersonalTraining
{
    public class EfGetPersonalTrainingQuery : EfFindUseCase<ResponsePersonalTrainingDTO, Domain.PersonalTraining>, IGetPersonalTrainingQuery
    {
        public EfGetPersonalTrainingQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id => 20;

        public override string Name => "PersonalTraining Search";
    }
}
