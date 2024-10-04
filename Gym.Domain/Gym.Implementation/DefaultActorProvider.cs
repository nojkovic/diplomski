using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application;

namespace Gym.Implementation
{
    public class DefaultActorProvider : IApplicationActorProvider
    {
        public IApplicationActor GetActor()
        {
            return new Actor
            {
                Username = "lastuser",
                Email = "user@gmail.com",
                Id = 2,
                FirstName = "User1",
                LastName = "Lastname"
            };
        }
    }
}
