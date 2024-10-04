using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.CoachTraining;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.CoachTraining
{
    public class AddCoachTrainingDTOValidator : CoachTrainingBaseValidator<CoachTrainingDTO>
    {
        public AddCoachTrainingDTOValidator(GymContext ctx) : base(ctx)
        {
        }
    }
}
