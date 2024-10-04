using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.GymTraining;

namespace Gym.Application.UseCases.Commands.GymTraining
{
    public interface IUpdateGymTrainingCommand : ICommand<UpdateGymTrainingDTO>
    {
    }
}
