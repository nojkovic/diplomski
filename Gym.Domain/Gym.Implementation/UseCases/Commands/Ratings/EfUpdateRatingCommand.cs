using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Rating;
using Gym.Application.UseCases.Commands.Ratings;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Exceptions;
using Gym.Implementation.Validators.Rating;

namespace Gym.Implementation.UseCases.Commands.Ratings
{
    public class EfUpdateRatingCommand : EfUseCase, IUpdateRatingCommand
    {
        private RatingValidator _validator;
        public EfUpdateRatingCommand(GymContext context, RatingValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 68;

        public string Name => "Rating Update";

        public void Execute(UpdateRatingDTO data)
        {
            Rating rating = Context.Ratings.FirstOrDefault(x => x.Id == data.Id);

            if (rating == null || !rating.IsActive)
            {
                throw new NotFoundException(nameof(Rating), data.Id);
            }

            _validator.ValidateAndThrow(data);

            rating.Rate = data.Rate;
            rating.UserId = data.UserId;
            rating.GymId = data.GymId;
            rating.Message = data.Message;
            rating.UpdatedAt = DateTime.UtcNow;

            Context.SaveChanges();
        }
    }
}
