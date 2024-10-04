using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Rating;
using Gym.Application.DTO.User;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.User
{
    public class EfGetUserQuery : EfFindUseCase<UserDTO, Domain.User>, IGetUserQuery
    {
        public EfGetUserQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id => 72;

        public override string Name => "Get User";
    }
}
