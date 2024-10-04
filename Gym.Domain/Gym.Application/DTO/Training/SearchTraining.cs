using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.Training
{
    public class SearchTraining : PagedSearch
    {
        public string Keyword { get; set; }
    }
}
