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
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.Users
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        private DeleteUserDTOValidator _validator;

        public EfDeleteUserCommand(GymContext context, DeleteUserDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "User Delete";

        
        public void Execute(BaseUserDto data)
        {
            _validator.ValidateAndThrow(data);
            User user = Context.Users.Include(x => x.Reservations)
                                    .FirstOrDefault(x => x.Id == data.Id);

            var userReservation = user.Reservations;

            foreach(var r in userReservation) {
                r.IsActive = false;
            
            }
            user.IsActive = false;
            Context.Entry(user).State = EntityState.Modified;
            Context.SaveChanges();



        }
    }
}
