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
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        public int Id => 1;

        public string Name => "User Registration";

        private RegisterUserDtoValidator _validator;


        public EfRegisterUserCommand(GymContext context, RegisterUserDtoValidator validator)
            : base(context)
        {
            _validator = validator;

        }
        private List<int> allowedCasesForUser = new List<int>
        {
            10,11,15,16,20,21,25,26,30,31,35,36,40,41,45,46,50,51,55,56,60,61,62,63,64,65,66,75,71,80,67

        };


        public void Execute(RegisterUserDTO data)
        {
            _validator.ValidateAndThrow(data);

            User user = new User
            {

                Email = data.Email,
                Name = data.Name,
                LastName = data.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                Contact = data.Contact,
                IsActivated = false,
                UseCases = allowedCasesForUser.Select(u => new UserUseCase
                {
                    UseCaseId = u
                }).ToList()



            };


            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
