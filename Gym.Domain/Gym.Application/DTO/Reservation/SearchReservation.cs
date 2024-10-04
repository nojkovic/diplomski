using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.Reservation
{
    public class SearchReservation : PagedSearch
    {
        public string UserEmail { get; set; }
        public int? UserId { get; set; }
        public string GymAdress { get; set; }
        public string CoachName { get; set; }
        public string Status { get; set; }
    }
}
