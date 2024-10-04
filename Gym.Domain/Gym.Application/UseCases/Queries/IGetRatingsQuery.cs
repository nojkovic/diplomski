using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Rating;
using Gym.Application.DTO;

namespace Gym.Application.UseCases.Queries
{
    public interface IGetRatingsQuery : IQuery<PagedResponse<ResponseRatingDTO>, SearchRatingDTO>
    {
    }
}
