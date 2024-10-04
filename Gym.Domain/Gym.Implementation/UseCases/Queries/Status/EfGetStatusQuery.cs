using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO;
using Gym.Application.DTO.MembershipFee;
using Gym.Application.DTO.Status;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Status
{
    public class EfGetStatusQuery : EfUseCase, IGetStatusQuery
    {
        private readonly IMapper _mapper;
        public EfGetStatusQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 31;

        public string Name => "Status Search";

        public PagedResponse<ResponseStatusDTO> Execute(SearchStatus search)
        {
            var query = Context.Status.Where(x => x.IsActive).AsQueryable();


            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }
            var st = query.ToList();

            return query.AsPagedReponse<Domain.Status, ResponseStatusDTO>(search, _mapper);
        }
    }
}
