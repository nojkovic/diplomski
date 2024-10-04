using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.CoachTraining;

namespace Gym.Application.UseCases.Commands.CoachTrainings
{
    public interface IDeleteCoachTrainingCommand : ICommand<BaseCoachTrainingDTO>
    {
    }
}
