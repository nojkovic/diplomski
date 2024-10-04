using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gym.Domain
{
    public class User : NamedEntity
    {
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public bool IsActivated { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }= new HashSet<Reservation>();
        public virtual ICollection<UserUseCase> UseCases { get; set; } = new HashSet<UserUseCase>();
        public virtual ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();

    }
}
