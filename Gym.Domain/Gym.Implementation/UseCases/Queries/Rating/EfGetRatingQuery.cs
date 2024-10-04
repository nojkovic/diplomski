using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Rating;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;
using Gym.Domain;

namespace Gym.Implementation.UseCases.Queries.Rating
{
    public class EfGetRatingQuery : EfFindUseCase<ResponseRatingDTO, Domain.Rating>, IGetRatingQuery
    {
        public EfGetRatingQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id => 70;

        public override string Name => "Get Rating";
    }
}
