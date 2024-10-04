using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.Contact
{
    public class ContactSearch : PagedSearch
    {
        public string Keyword { get; set; }

    }
}
