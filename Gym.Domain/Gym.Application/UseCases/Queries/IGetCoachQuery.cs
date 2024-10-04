using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.GroupTraining;

namespace Gym.Application.UseCases.Queries
{
    public interface IGetCoachQuery : IQuery<ResponseCoachDTO, int>
    {
    }
}
