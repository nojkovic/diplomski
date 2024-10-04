using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.User
{
    public class UserSearch : PagedSearch
    {
        public string Keyword { get; set; }
        public bool? IsActivated { get; set; }

    }

    public class UserUpdatePatch
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public bool? IsActivated { get; set; }
    }
}
