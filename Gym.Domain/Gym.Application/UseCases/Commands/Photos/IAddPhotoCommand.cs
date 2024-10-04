using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Photo;

namespace Gym.Application.UseCases.Commands.Photos
{
    public interface IAddPhotoCommand:ICommand<PhotoDTO>
    {
    }
}
