using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Coach;
using Gym.Application.UseCases.Commands.Coach;
using Gym.Application.UseCases.Commands.Photos;
using Gym.DataAccess;
using Gym.Implementation.Validators.Coach;

namespace Gym.Implementation.UseCases.Commands.Coachs
{
    public class EfUpdateCoachCommand : EfUseCase, IUpdateCoachCommand
    {
        private UpdateCoachDTOValidator validator;
        public EfUpdateCoachCommand(GymContext context, UpdateCoachDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 38;

        public string Name => "Coach Update";

        public void Execute(UpdateCoachDTO data)
        {
            validator.ValidateAndThrow(data);


            var coach = Context.Coachs.FirstOrDefault(p => p.Id == data.Id);

            if (coach != null)
            {

                var oldFilePath = Path.Combine("wwwroot", "coach", coach.Photo);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }

                coach.Name = data.Name;
                coach.LastName = data.LastName;
                coach.Description = data.Description;
                coach.Photo = data.Photo;
                coach.IsActive = true;
                coach.GymId = data.GymId;
               

                Context.SaveChanges();

                var tempFile = Path.Combine("wwwroot", "temp", data.Photo);
                var destinationFile = Path.Combine("wwwroot", "coach", data.Photo);
                System.IO.File.Move(tempFile, destinationFile);
            }
        }
    }
}
