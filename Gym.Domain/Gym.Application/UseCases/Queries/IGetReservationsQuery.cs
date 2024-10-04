using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO;
using Gym.Application.DTO.Reservation;

namespace Gym.Application.UseCases.Queries
{
    public interface IGetReservationsQuery : IQuery<PagedResponse<ResponseReservationDTO>, SearchReservation>
    {
    }
}
