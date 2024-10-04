using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Photo;
using Gym.Application.UseCases.Commands.Photos;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.Photo;

namespace Gym.Implementation.UseCases.Commands.Photo
{
    public class EfAddPhotoCommand : EfUseCase, IAddPhotoCommand
    {
        private AddPhotoDTOValidator _validator;
        public EfAddPhotoCommand(GymContext context, AddPhotoDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 32;

        public string Name => "Photo Add";

        public void Execute(PhotoDTO data)
        {
            _validator.ValidateAndThrow(data);


            var tempFile = Path.Combine("wwwroot", "temp", data.Path);
            var destinationFile = Path.Combine("wwwroot", "gym", data.Path);
            System.IO.File.Move(tempFile, destinationFile);


           Domain.Photo photo = new Domain.Photo
            {

                GymId = data.GymId,
                Path = data.Path,



            };

            Context.Photos.Add(photo);

            Context.SaveChanges();
        }
    }
}
