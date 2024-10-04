using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class GymTraining:Entity
    {
        public int GymId { get; set; }
        public int TrainingId { get; set; }
        public virtual Gym Gym { get; set; }
        public virtual Training Training { get; set; }
    }
}
