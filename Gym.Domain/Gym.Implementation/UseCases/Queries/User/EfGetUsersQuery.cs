using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO;
using Gym.Application.DTO.Rating;
using Gym.Application.DTO.User;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gym.Implementation.UseCases.Queries.User
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        private readonly IMapper _mapper;
        public EfGetUsersQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 3;

        public string Name => "Get Users";


        public PagedResponse<UserDTO> Execute(UserSearch search)
        {
            var query = Context.Users.Where(x => x.IsActive).AsQueryable();

            if (search.IsActivated.HasValue)
            {
                query = query.Where(x => x.IsActivated == search.IsActivated);
            }

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()) || x.LastName.ToLower().Contains(search.Keyword.ToLower()) || x.Email.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.AsPagedReponse<Domain.User, UserDTO>(search, _mapper);

        }
    }
}
