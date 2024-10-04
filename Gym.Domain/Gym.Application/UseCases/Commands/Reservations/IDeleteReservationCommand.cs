using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.PersonalTraining;
using Gym.Application.DTO.Reservation;

namespace Gym.Application.UseCases.Commands.Reservations
{
    public interface IDeleteReservationCommand : ICommand<BaseReservationDTO>
    {
    }
}
