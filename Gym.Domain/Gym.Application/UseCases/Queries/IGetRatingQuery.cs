using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Rating;

namespace Gym.Application.UseCases.Queries
{
    public interface IGetRatingQuery : IQuery<ResponseRatingDTO, int>
    {
    }
}
