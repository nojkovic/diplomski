using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.CoachTraining
{
    public class SearchCoachTraining : PagedSearch
    {
        public int? TrainingId { get; set; }
        public int? CoachId { get; set; }
        public int? GymId { get; set; }
    }
}
