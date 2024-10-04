using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class Photo:Entity
    {
        public string Path { get; set; }
        public int GymId { get; set; }

        public virtual Gym Gym { get; set; }
    }
}
