using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.User;
using Gym.Application.UseCases.Commands.Users;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.Users;

namespace Gym.Implementation.UseCases.Commands.Users
{
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {

        private UpdateUserDTOValidator _validator;
        public EfUpdateUserCommand(GymContext context, UpdateUserDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 4;

        public string Name => "User Update";

        public void Execute(UpdateUserDto data)
        {
            _validator.ValidateAndThrow(data);
            User user = Context.Users.First(x => x.Id == data.Id);
            user.Name = data.Name;
            user.Email = data.Email;
            user.LastName = data.LastName;
            user.Contact = data.Contact;
            user.Password = data.Password;
            user.IsActive = true;
            user.IsActivated = data.IsActivated;


            Context.SaveChanges();
        }
    }
}
