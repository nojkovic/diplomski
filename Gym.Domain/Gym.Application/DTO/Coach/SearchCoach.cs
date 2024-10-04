using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.Coach
{
    public class SearchCoach : PagedSearch
    {
        public string Keyword { get; set; }
        public int? GymId { get; set; }
    }
}
