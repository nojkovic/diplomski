using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.User;
using Gym.Application.UseCases.Commands.Users;
using Gym.DataAccess;
using Gym.Domain;
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.Users
{
    public class EfModifyAccessCommand : EfUseCase, IModifyAccessCommand
    {
        public EfModifyAccessCommand(GymContext context) : base(context)
        {
        }

        public int Id => 73;

        public string Name => "Modify Access";

        public void Execute(UserUpdatePatch data)
        {
            User user = Context.Users.First(x => x.Id == data.Id);

            if(data.Name != null)
            {
                user.Name = data.Name;
            }

            if (data.LastName != null)
            {
                user.LastName = data.LastName;
            }

            if (data.Email != null)
            {
                user.Email = data.Email;
            }

            if(data.Contact !=null)
            {
                user.Contact = data.Contact;
            }

            if (data.IsActivated.HasValue)
            {
                user.IsActivated = data.IsActivated.Value;
            }

            Context.SaveChanges();
        }
    }
}
