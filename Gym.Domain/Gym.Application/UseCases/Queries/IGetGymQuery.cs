using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Gym;

namespace Gym.Application.UseCases.Queries
{
    public interface IGetGymQuery : IQuery<ResponseGymDTO, int>
    {
    }
}
