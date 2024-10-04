using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Photo;
using Gym.Application.UseCases.Commands.Photos;
using Gym.DataAccess;
using Gym.Implementation.Validators.Photo;

namespace Gym.Implementation.UseCases.Commands.Photo
{
    public class EfUpdatePhotoCommand : EfUseCase, IUpdatePhotoCommand
    {
        private UpdatePhotoDTOValidator validator;
        public EfUpdatePhotoCommand(GymContext context, UpdatePhotoDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 33;

        public string Name => "Photo Update";

        public void Execute(UpdatePhotoDTO data)
        {
            validator.ValidateAndThrow(data);


            var existingPhoto = Context.Photos.FirstOrDefault(p => p.GymId == data.GymId);

            if (existingPhoto != null)
            {

                var oldFilePath = Path.Combine("wwwroot", "gym", existingPhoto.Path);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }

                Context.Photos.Remove(existingPhoto);
            }

            var tempFile = Path.Combine("wwwroot", "temp", data.Path);
            var destinationFile = Path.Combine("wwwroot", "gym", data.Path);
            System.IO.File.Move(tempFile, destinationFile);


            Domain.Photo newPhoto = new Domain.Photo
            {
                GymId = data.GymId,
                Path = data.Path,
            };

            Context.Photos.Add(newPhoto);

            Context.SaveChanges();
        }
    }
}
