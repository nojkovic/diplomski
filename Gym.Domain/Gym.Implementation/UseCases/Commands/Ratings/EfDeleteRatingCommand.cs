using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.UseCases.Commands.Ratings;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Exceptions;

namespace Gym.Implementation.UseCases.Commands.Ratings
{
    public class EfDeleteRatingCommand : EfUseCase, IDeleteRatingCommand
    {
        public EfDeleteRatingCommand(GymContext context) : base(context)
        {
        }

        public int Id => 69;

        public string Name => "Rating Delete";  

        public void Execute(int data)
        {
            Rating rating = Context.Ratings.FirstOrDefault(x => x.Id == data);

            if (rating == null || !rating.IsActive)
            {
                throw new NotFoundException(nameof(Rating), data);
            }

            rating.IsActive = false;

            Context.SaveChanges();
        }
    }
}
