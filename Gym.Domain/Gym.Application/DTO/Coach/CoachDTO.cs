using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.Coach
{
    public class CoachDTO:BaseCoachDTO
    {
        public IEnumerable<int> TrainingIds { get; set; }
    }
}
