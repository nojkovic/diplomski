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
    public class PhotoBaseValidator<T> : AbstractValidator<T>
        where T : BasePhotoDTO
    {
        public PhotoBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.GymId)
                .NotEmpty().WithMessage("Gym is required.")
                .Must(x => ctx.Gyms.Any(c => c.Id == x))
                .WithMessage(" GymId doesn't exist.");
            RuleFor(x => x.Path).NotEmpty()
                        .WithMessage("At least one image is required.")
                        .DependentRules(() =>
                        {
                            RuleFor(x => x.Path).Must((x, fileName) =>
                            {
                                var path = Path.Combine("wwwroot", "temp", fileName);

                                var exists = Path.Exists(path);

                                return exists;
                            }).WithMessage("File doesn't exist.");
                        });
        }

    }
}
