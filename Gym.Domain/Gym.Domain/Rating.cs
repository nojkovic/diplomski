using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class Rating : Entity
    {
        public int Rate { get; set; }
        public int UserId { get; set; }
        public int GymId { get; set; }
        public string Message { get; set; }

        public virtual Gym Gym { get; set; }
        public virtual User User { get; set; }

    }
}
