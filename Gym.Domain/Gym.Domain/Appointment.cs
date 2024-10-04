using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class Appointment:Entity
    {
        public int CoachTrainingId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public int GymId { get; set; }

        public virtual CoachTraining CoachTraining { get; set; }
        public virtual Gym Gym { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }
}
