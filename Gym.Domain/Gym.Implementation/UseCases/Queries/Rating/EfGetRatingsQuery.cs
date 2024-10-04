using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Rating;
using Gym.Application.DTO;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Rating
{
    public class EfGetRatingsQuery : EfUseCase, IGetRatingsQuery
    {
        private readonly IMapper _mapper;
        public EfGetRatingsQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 71;

        public string Name => "Get Ratings";

        public PagedResponse<ResponseRatingDTO> Execute(SearchRatingDTO data)
        {
            var query = Context.Ratings.Where(x => x.IsActive).AsQueryable();

            if (data.Id.HasValue)
            {
                query = query.Where(x => x.Id == data.Id);
            }

            if (data.Rate.HasValue)
            {
                query = query.Where(x => x.Rate == data.Rate);
            }

            if (data.GymId.HasValue)
            {
                query = query.Where(x => x.GymId == data.GymId);
            }

            if (data.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == data.UserId);
            }

            if (!string.IsNullOrEmpty(data.Message))
            {
                query = query.Where(x => x.Message.ToLower().Contains(data.Message.ToLower()));
            }

            if (!string.IsNullOrEmpty(data.GymName))
            {
                query = query.Where(x => x.Gym.Name.Contains(data.GymName));
            }

            if (!string.IsNullOrEmpty(data.UserName))
            {
                query = query.Where(x => x.User.Name.Contains(data.UserName));
            }

            return query.AsPagedReponse<Domain.Rating, ResponseRatingDTO>(data, _mapper);
        }
    }
}
