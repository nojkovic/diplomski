using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.GymTraining
{
    public class SearchGymTraining : PagedSearch
    {
        public int? TrainingId { get; set; }
        public int? GymId { get; set; }
    }
}
