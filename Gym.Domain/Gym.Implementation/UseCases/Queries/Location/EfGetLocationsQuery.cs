using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.DTO.Location;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Location
{
    public class EfGetLocationsQuery : EfUseCase, IGetLocationsQuery
    {
        private readonly IMapper _mapper;
        public EfGetLocationsQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id =>26;

        public string Name =>"Locations Search";

        public PagedResponse<ResponseLocationDTO> Execute(SearchLocation search)
        {
            var query = Context.Locations.Where(x => x.IsActive).AsQueryable();


            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Address.ToLower().Contains(search.Keyword.ToLower()) || x.City.ToLower().Contains(search.Keyword.ToLower()));
            }
            var groupt = query.ToList();

            return query.AsPagedReponse<Domain.Location, ResponseLocationDTO>(search, _mapper);
        }
    }
}
