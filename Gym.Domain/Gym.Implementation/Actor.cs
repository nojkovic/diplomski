using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application;

namespace Gym.Implementation
{
    public class Actor : IApplicationActor
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public IEnumerable<int> AllowedUseCases { get; set; }

    }

    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0;

        public string Username => "unauthorized";

        public string Email => "/";

        public string FirstName => "unauthorized";

        public string LastName => "unauthorized";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1,10,11,15,16,20,21,25,26,35,36,40,41,45,46,55,50,51,56,61,67,71,75 };
    }
}

