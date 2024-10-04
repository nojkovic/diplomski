using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Rating;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Rating
{
    public class RatingValidator : AbstractValidator<RatingDTO>
    {
        public RatingValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.GymId).NotEmpty()
                                        .WithMessage("Gym is required.")
                                        .Must(x => ctx.Gyms.Any(a => a.Id == x && a.IsActive))
                                        .WithMessage("Gym does not exists.");

            RuleFor(x => x.Rate).NotEmpty()
                                        .WithMessage("Rate is required.")
                                        .Must(rate => int.TryParse(rate.ToString(), out _))
                                        .WithMessage("Rate must be an integer.")
                                        .InclusiveBetween(1, 5)
                                        .WithMessage("Rate must be between 1 and 5.");

            RuleFor(x => x.UserId).NotEmpty()
                                        .WithMessage("User is required.")
                                        .Must(x => ctx.Users.Any(a => a.Id == x && a.IsActive))
                                        .WithMessage("User does not exists.");
        }
    }
}
