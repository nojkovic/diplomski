using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Photo;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Photo
{
    public class AddPhotoDTOValidator : PhotoBaseValidator<PhotoDTO>
    {
        public AddPhotoDTOValidator(GymContext ctx) : base(ctx)
        {
        }
    }
}
