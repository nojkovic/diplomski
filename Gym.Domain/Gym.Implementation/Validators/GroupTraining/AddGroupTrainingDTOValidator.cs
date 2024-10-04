using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.GroupTraining;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.GroupTraining
{
    public class AddGroupTrainingDTOValidator : GroupTrainingBaseValidator<GroupTrainingDTO>
    {
        public AddGroupTrainingDTOValidator(GymContext ctx) : base(ctx)
        {
        }
    }
}
