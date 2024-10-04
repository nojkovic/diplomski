using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO;
using Gym.Application.DTO.PersonalTraining;
using Gym.Application.DTO.Photo;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Photo
{
    public class EfGetPhotosQuery : EfUseCase, IGetPhotosQuery
    {
        private readonly IMapper _mapper;
        public EfGetPhotosQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 36;

        public string Name => "Photos Search";

        public PagedResponse<ResponsePhotoDTO> Execute(SearchPhoto search)
        {
            var query = Context.Photos.Where(x => x.IsActive).AsQueryable();


            if (search.GymId.HasValue)
            {
                query = query.Where(x => x.GymId == search.GymId);
            }

            var groupt = query.ToList();

            return query.AsPagedReponse<Domain.Photo, ResponsePhotoDTO>(search, _mapper);
        }
    }
}
