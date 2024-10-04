using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.PersonalTraining;
using Gym.Application.DTO.Status;
using Gym.DataAccess;
using Gym.Implementation.Validators.PersonalTraining;

namespace Gym.Implementation.Validators.Status
{
    public class AddStatusDTOValidator : StatusBaseValidator<StatusDTO>
    {
        public AddStatusDTOValidator(GymContext ctx) : base(ctx)
        {
        }
    }
}
