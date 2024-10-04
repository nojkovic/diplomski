using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Location;

namespace Gym.Application.UseCases.Commands.Coach
{
    public interface IDeleteCoachCommand : ICommand<BaseCoachDTO>
    {
    }
}
