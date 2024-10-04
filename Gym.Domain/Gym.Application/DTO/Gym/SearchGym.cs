using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.Gym
{
    public class SearchGym : PagedSearch
    {
        public string Keyword { get; set; }
        public int? Location { get; set; }
    }
}
