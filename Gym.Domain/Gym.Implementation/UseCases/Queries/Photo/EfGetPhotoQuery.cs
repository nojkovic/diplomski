using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Location;
using Gym.Application.DTO.Photo;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Photo
{
    public class EfGetPhotoQuery : EfFindUseCase<ResponsePhotoDTO, Domain.Photo>, IGetPhotoQuery
    {
        public EfGetPhotoQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id => 35;

        public override string Name => "Photo Search";
    }
}
