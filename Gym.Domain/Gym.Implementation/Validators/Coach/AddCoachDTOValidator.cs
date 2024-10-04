using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Coach;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Coach
{
    public class AddCoachDTOValidator : CoachBaseValidator<CoachDTO>
    {
        public AddCoachDTOValidator(GymContext ctx) : base(ctx)
        {
        }
    }
}
