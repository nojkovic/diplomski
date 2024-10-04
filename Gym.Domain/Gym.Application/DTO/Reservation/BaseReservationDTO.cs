using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.Reservation
{
    public class BaseReservationDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GymId { get; set; }
        public int CoachId { get; set; }
        public int AppointmentId { get; set; }
        public int StatusId { get; set; }

    }
}
