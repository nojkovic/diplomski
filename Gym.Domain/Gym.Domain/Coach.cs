using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class Coach:NamedEntity
    {
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int GymId { get; set; }
        //public IEnumerable<int> TrainingIds { get; set; }


        public virtual Gym Gym { get; set; }

        public virtual ICollection<CoachTraining> CoachTrainings { get; set; } = new HashSet<CoachTraining>();
        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }
}
