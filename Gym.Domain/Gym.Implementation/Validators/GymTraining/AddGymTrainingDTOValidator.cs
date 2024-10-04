using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.GymTraining;
using Gym.DataAccess;
using Gym.Implementation.Validators.CoachTraining;

namespace Gym.Implementation.Validators.GymTraining
{
    public class AddGymTrainingDTOValidator : GymTrainingBaseValidator<GymTrainingDTO>
    {
        public AddGymTrainingDTOValidator(GymContext ctx) : base(ctx)
        {
        }
    }
}
