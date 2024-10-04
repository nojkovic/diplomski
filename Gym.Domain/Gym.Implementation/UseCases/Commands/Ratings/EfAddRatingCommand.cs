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
using Gym.Implementation.Validators.Rating;

namespace Gym.Implementation.UseCases.Commands.Ratings
{
    public class EfAddRatingCommand : EfUseCase, IAddRatingCommand
    {
        private RatingValidator _validator;
        public EfAddRatingCommand(GymContext context, RatingValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 67;

        public string Name => "Rating Add";

        public void Execute(RatingDTO data)
        {
            _validator.ValidateAndThrow(data);

            Rating rating = new Rating
            {
                Rate = data.Rate,
                UserId = data.UserId,
                Message = data.Message,
                GymId = data.GymId
            };
            Context.Ratings.Add(rating);
            Context.SaveChanges();
        }
    }
}
