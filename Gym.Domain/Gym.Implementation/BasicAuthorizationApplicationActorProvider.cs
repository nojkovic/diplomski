using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application;
using Gym.DataAccess;
using Gym.Domain;

namespace Gym.Implementation
{
    public class BasicAuthorizationApplicationActorProvider : IApplicationActorProvider
    {
        private string _authorizationHeader;
        private GymContext _context;

        public BasicAuthorizationApplicationActorProvider(string authorizationHeader, GymContext context)
        {
            _authorizationHeader = authorizationHeader;
            _context = context;
        }

        public IApplicationActor GetActor()
        {
            //if (_authorizationHeader == null || !_authorizationHeader.Contains("Basic"))
            //{
            //    return new UnauthorizedActor();
            //}

            //var base64Data = _authorizationHeader.Split(" ")[1];

            //var bytes = Convert.FromBase64String(base64Data);

            //var decodedCredentials = System.Text.Encoding.UTF8.GetString(bytes);

            //if (decodedCredentials.Split(":").Length < 2)
            //{
            //    throw new InvalidOperationException("Invalid Basic authorization header.");
            //}

            //string username = decodedCredentials.Split(":")[0];
            //string password = decodedCredentials.Split(":")[1];

            User u = _context.Users.FirstOrDefault(x => x.Email == "lastuser" && x.Password == "user123");

            if (u == null)
            {
                return new UnauthorizedActor();
            }

            var useCases = _context.UserUseCases.Select(x => x.UseCaseId).ToList();

            return new Actor
            {
                Email = u.Email,
                FirstName = u.Name,
                Id = u.Id,
                LastName = u.LastName,
                AllowedUseCases = useCases
            };
        }
    }
}
