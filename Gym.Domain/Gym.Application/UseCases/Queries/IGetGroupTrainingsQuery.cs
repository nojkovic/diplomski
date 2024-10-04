using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO;
using Gym.Application.DTO.GroupTraining;

namespace Gym.Application.UseCases.Queries
{
    public interface IGetGroupTrainingsQuery : IQuery<PagedResponse<ResponseGroupTrainingDTO>, SearchGroupTraining>
    {
    }
}
