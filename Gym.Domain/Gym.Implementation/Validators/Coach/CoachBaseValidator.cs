using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Photo;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Coach
{
    public class CoachBaseValidator<T> : AbstractValidator<T>
        where T : BaseCoachDTO
    {
        public CoachBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required.");
            RuleFor(x => x.GymId).Must(x => ctx.Gyms.Any(u => u.Id == x))
              .WithMessage("GymId must exists").NotEmpty();
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.Photo).NotEmpty()
                        .WithMessage("At least one image is required.")
                        .DependentRules(() =>
                        {
                            RuleFor(x => x.Photo).Must((x, fileName) =>
                            {
                                var path = Path.Combine("wwwroot", "temp", fileName);

                                var exists = Path.Exists(path);

                                return exists;
                            }).WithMessage("File doesn't exist.");
                        });
        }

    }
}
