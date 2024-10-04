using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.GroupTraining;

namespace Gym.Application.UseCases.Queries
{
    public interface IGetCoachTrainingQuery : IQuery<ResponseCoachTrainingDTO, int>
    {
    }
}
