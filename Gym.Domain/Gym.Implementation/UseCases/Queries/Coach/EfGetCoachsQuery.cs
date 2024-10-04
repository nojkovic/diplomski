using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Coach
{
    public class EfGetCoachsQuery : EfUseCase, IGetCoachsQuery
    {
        private readonly IMapper _mapper;
        public EfGetCoachsQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 41;

        public string Name => "Coachs Search";

        public PagedResponse<ResponseCoachDTO> Execute(SearchCoach search)
        {
            var query = Context.Coachs.Where(x => x.IsActive).AsQueryable();


            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower())|| x.LastName.ToLower().Contains(search.Keyword.ToLower()));
            }

            if(search.GymId.HasValue) 
            {
                query = query.Where(x => x.GymId==search.GymId);

            }
            var groupt = query.ToList();

            return query.AsPagedReponse<Domain.Coach, ResponseCoachDTO>(search, _mapper);
        }
    }
}
