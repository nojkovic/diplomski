using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class Contact:NamedEntity
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
