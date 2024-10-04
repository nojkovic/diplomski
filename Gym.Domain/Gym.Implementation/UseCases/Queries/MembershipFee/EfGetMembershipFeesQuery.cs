using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO;
using Gym.Application.DTO.MembershipFee;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gym.Implementation.UseCases.Queries.MembershipFee
{
    public class EfGetMembershipFeesQuery : EfUseCase, IGetMembershipFeesQuery
    {
        private readonly IMapper _mapper;
        public EfGetMembershipFeesQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 11;

        public string Name => "MembershipFees Search";

        public PagedResponse<ResponseMembershipFeeDTO> Execute(SearchMembershipFee search)
        {
            var query = Context.MembershipFees.Where(x => x.IsActive).AsQueryable();


            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.TypeOfMembership.ToLower().Contains(search.Keyword.ToLower()));
            }
            var membfee = query.ToList();

            return query.AsPagedReponse<Domain.MembershipFee, ResponseMembershipFeeDTO>(search, _mapper);
        }
    }
}
