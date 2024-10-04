using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Location;
using Gym.Application.DTO.Status;

namespace Gym.Application.UseCases.Commands.Status
{
    public interface IDeleteStatusCommand : ICommand<BaseStatusDTO>
    {
    }
}
