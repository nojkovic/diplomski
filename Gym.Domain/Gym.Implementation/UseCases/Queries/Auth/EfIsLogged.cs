using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application;
using Gym.Application.DTO;
using Gym.Application.DTO.Gym;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Auth
{
    public class EfIsLogged : EfUseCase, IIsLogged
    {
        private IApplicationActor _actor;
        public EfIsLogged(GymContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 75;

        public string Name => "Is Logged";

        public LoggedDTO Execute(SearchGym data)
        {
            if(_actor.Email != "/")
            {
                return new LoggedDTO
                {
                    IsLogged = true,
                };
            }
            return new LoggedDTO { IsLogged = false };
        }
    }
}
