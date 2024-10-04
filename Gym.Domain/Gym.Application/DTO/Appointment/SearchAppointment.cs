using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.Appointment
{
    public class SearchAppointment : PagedSearch
    {
        public int? CoachTrainingId { get; set; }
        public int? GymId { get; set; }
    }
}
