using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.PersonalTraining;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.PersonalTraining
{
    public class AddPersonalTrainingDTOValidator : PersonalTrainingBaseValidator<PersonalTrainingDTO>
    {
        public AddPersonalTrainingDTOValidator(GymContext ctx) : base(ctx)
        {
        }
    }
}
