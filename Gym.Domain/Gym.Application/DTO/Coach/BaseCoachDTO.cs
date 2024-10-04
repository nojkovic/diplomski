using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.Coach
{
    public class BaseCoachDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int GymId { get; set; }
    }
}
