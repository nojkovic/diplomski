using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.DTO;
using Gym.Application.DTO.Training;

namespace Gym.Application.UseCases.Queries
{
    public interface IGetTrainingsQuery : IQuery<PagedResponse<ResponseTrainingDTO>, SearchTraining>
    {
    }
}
