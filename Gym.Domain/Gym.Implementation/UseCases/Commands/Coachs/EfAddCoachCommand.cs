using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Coach;
using Gym.Application.UseCases.Commands.Coach;
using Gym.DataAccess;
using Gym.Implementation.Validators.Coach;

namespace Gym.Implementation.UseCases.Commands.Coachs
{
    public class EfAddCoachCommand : EfUseCase, IAddCoachCommand
    {
        private AddCoachDTOValidator validator;
        public EfAddCoachCommand(GymContext context, AddCoachDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 37;

        public string Name => "Coach Add";

        public void Execute(CoachDTO data)
        {
            validator.ValidateAndThrow(data);


            var tempFile = Path.Combine("wwwroot", "temp", data.Photo);
            var destinationFile = Path.Combine("wwwroot", "coach", data.Photo);
            System.IO.File.Move(tempFile, destinationFile);


            Domain.Coach coach = new Domain.Coach
            {

                Name= data.Name,
                LastName= data.LastName,
                Description= data.Description,
                Photo= data.Photo ?? "avatar.jpg",
                GymId= data.GymId,

            };

            Context.Coachs.Add(coach);

            Context.SaveChanges();
        }
    }
}
