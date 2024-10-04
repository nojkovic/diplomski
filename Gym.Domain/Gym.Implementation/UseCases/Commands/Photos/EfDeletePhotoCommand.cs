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
    public class EfDeletePhotoCommand : EfUseCase, IDeletePhotoCommand
    {
        private DeletePhotoDTOValidator validator;
        public EfDeletePhotoCommand(GymContext context, DeletePhotoDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 34;

        public string Name => "Photo Delete";

        public void Execute(BasePhotoDTO data)
        {
            validator.ValidateAndThrow(data);

            var photo = Context.Photos.FirstOrDefault(p => p.Id == data.Id);

            photo.IsActive = false;
    
            Context.SaveChanges();
        }
    }
}
