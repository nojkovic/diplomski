using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.PersonalTraining
{
    public class SearchPersonalTraining : PagedSearch
    {
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? NumberOfTerm { get; set; }
    }
}
