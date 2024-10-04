using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Location;
using Gym.Application.DTO.Photo;

namespace Gym.Application.DTO.Gym
{
    public class GymDTO : BaseGymDTO
    {
        public LocationDTO Location { get; set; }
        public IEnumerable<string> PhotosString { get; set; }
        public IEnumerable<int> TrainingIds { get; set; }
        public IEnumerable<CoachDTO> Coaches { get; set; }

    }
}
