using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO;
using Gym.Application.DTO.GymTraining;

namespace Gym.Application.UseCases.Queries
{
    public interface IGetGymTrainingsQuery : IQuery<PagedResponse<ResponseGymTrainingDTO>, SearchGymTraining>
    {
    }
}
