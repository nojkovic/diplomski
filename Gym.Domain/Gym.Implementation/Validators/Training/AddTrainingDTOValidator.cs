using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Training;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Training
{
    public class AddTrainingDTOValidator : TrainingBaseValidator<TrainingDTO>
    {
        public AddTrainingDTOValidator(GymContext ctx) : base(ctx)
        {
        }
    }
}
