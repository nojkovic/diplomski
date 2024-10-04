using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class Reservation:Entity
    {
        public int UserId { get; set; }
        public int GymId { get; set;}
        public int CoachId { get; set; }
        public int AppointmentId { get; set;}
        public int StatusId { get; set; }

        public virtual User User { get; set; }
        public virtual Gym Gym { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual Status Status { get; set; }


    }
}
