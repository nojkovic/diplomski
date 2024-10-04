using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Location;
using Gym.Application.DTO.Reservation;
using Gym.Application.DTO.User;

namespace Gym.Application.UseCases.Queries
{
    public interface IGetUserQuery : IQuery<UserDTO, int>
    {
    }
}
