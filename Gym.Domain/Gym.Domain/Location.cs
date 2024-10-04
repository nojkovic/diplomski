using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class Location:Entity
    {
        public string Address { get; set; }
        public string City { get; set; }
        public virtual ICollection<Gym> Gyms { get; set; } = new HashSet<Gym>();
    }
}
