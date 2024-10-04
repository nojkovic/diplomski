using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.DTO.Gym;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Gym
{
    public class EfGetGymsQuery : EfUseCase, IGetGymsQuery
    {
        private readonly IMapper _mapper;
        public EfGetGymsQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 61;

        public string Name => "Gyms Search";

        public PagedResponse<ResponseGymsDTO> Execute(SearchGym search)
        {
            var query = Context.Gyms.Where(x => x.IsActive).AsQueryable();


            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Description.ToLower().Contains(search.Keyword.ToLower()) || x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }
            if (search.Location.HasValue)
            {
                query = query.Where(x => x.LocationId==search.Location);
            }
            var groupt = query.ToList();

            return query.AsPagedReponse<Domain.Gym, ResponseGymsDTO>(search, _mapper);
        }
    }
}
