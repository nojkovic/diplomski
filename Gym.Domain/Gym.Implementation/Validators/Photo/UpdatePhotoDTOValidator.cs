using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Photo;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Photo
{
    public class UpdatePhotoDTOValidator : PhotoBaseValidator<UpdatePhotoDTO>
    {
        public UpdatePhotoDTOValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.Photos.Any(u => u.Id == x))
                .WithMessage("Id must exists");
        }
    }
}
