using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.Reservation
{
    public class UpdateReservationDTO:BaseReservationDTO
    {
    }

    public class ReservationUpdatePatch
    {
        public int Id { get; set; }
        public int? StatusId { get; set; }
        
    }
}
