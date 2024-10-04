using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Training;

namespace Gym.Application.UseCases.Commands.Trainings
{
    public interface IAddTrainingCommand : ICommand<TrainingDTO>
    {
    }
}
