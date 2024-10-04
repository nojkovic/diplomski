using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Location;
using Gym.Application.DTO.PersonalTraining;

namespace Gym.Application.UseCases.Commands.Locations
{
    public interface IDeleteLocationCommand : ICommand<BaseLocationDTO>
    {
    }
}
