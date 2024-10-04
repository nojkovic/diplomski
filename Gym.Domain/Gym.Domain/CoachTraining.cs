using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class CoachTraining:Entity
    {
        public int CoachId { get; set; }
        public int TrainingId { get; set; }
        public int GymId { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual Gym Gym { get; set; }
        public virtual Training Training { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
