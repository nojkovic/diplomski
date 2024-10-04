using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.GroupTraining;

namespace Gym.Application.UseCases.Commands.GroupTrainings
{
    public interface IUpdateGroupTrainingCommand : ICommand<UpdateGroupTrainingDTO>
    {
    }
}
