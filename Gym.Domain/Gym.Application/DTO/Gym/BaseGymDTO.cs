using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Location;
using Gym.Application.DTO.Photo;

namespace Gym.Application.DTO.Gym
{
    public class BaseGymDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string WorkingTime { get; set; }
        public string WorkingTimeOnWeekend { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public IEnumerable<PhotoDTO> Photos { get; set; }
        
    }
}
