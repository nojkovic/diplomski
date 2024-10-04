using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class Gym:NamedEntity
    {
        public string Contact { get; set; }
        public string WorkingTime { get; set; }
        public string WorkingTimeOnWeekend { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }=new HashSet<Photo>();
        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
        public virtual ICollection<Coach> Coaches { get; set; } = new HashSet<Coach>();

        public virtual ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();
        public virtual ICollection<CoachTraining> CoachTraining { get; set; } = new HashSet<CoachTraining>();

        public virtual ICollection<GymTraining> GymTraining { get; set; } = new HashSet<GymTraining>();
    }
}
