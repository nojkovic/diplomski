using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Gym;
using Gym.Application.DTO.Location;

namespace Gym.Application.UseCases.Commands.Gyms
{
    public interface IDeleteGymCommand : ICommand<BaseGymDTO>
    {
    }
}
