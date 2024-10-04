using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Gym;
using Gym.Application.DTO.Reservation;
using Gym.DataAccess;
using Gym.Implementation.Validators.Gym;

namespace Gym.Implementation.Validators.Reservation
{
    public class AddReservationDTOValidator : ReservationBaseValidator<ReservationDTO>
    {
        public AddReservationDTOValidator(GymContext ctx) : base(ctx)
        {
        }
    }
}
