using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.PersonalTraining;

namespace Gym.Application.UseCases.Queries
{
    public interface IGetPersonalTrainingQuery : IQuery<ResponsePersonalTrainingDTO, int>
    {
    }
}
