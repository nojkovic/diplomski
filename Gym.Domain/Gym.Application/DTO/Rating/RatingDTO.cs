using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Gym;

namespace Gym.Application.DTO.Rating
{
    public class RatingDTO
    {
        public int Rate { get; set; }
        public int UserId { get; set; }
        public int GymId { get; set; }
        public string Message { get; set; }
    }

    public class UpdateRatingDTO : RatingDTO
    {
        public int Id { get; set; }
    }

    public class ResponseRatingDTO : UpdateRatingDTO
    {
        public ResponseBaseUser User { get; set; }
        public GymDTO Gym { get; set; }
    }

    public class ResponseBaseUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class SearchRatingDTO : PagedSearch
    {
        public int? Id { get; set; }
        public int? Rate { get; set; }
        public int? UserId { get; set; }
        public int? GymId { get; set; }
        public string Message { get; set; }
        public string GymName { get; set; }
        public string UserName { get; set; }


    }

}
