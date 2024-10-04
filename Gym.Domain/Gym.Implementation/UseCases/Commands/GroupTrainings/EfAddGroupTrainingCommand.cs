using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.UseCases.Commands.GroupTrainings;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.GroupTraining;

namespace Gym.Implementation.UseCases.Commands.GroupTrainings
{
    public class EfAddGroupTrainingCommand : EfUseCase, IAddGroupTrainingCommand
    {
        private AddGroupTrainingDTOValidator validator;
        public EfAddGroupTrainingCommand(GymContext context, AddGroupTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 12;

        public string Name => "GroupTraining Add";

        public void Execute(GroupTrainingDTO data)
        {
            validator.ValidateAndThrow(data);

            GroupTraining gt = new GroupTraining
            {
                TypeOfTraining = data.TypeOfTraining,
                Description = data.Description,
                PricePerTerm = data.PricePerTerm,

            };

            Context.GroupTrainings.Add(gt);
            Context.SaveChanges();

        }
    }
}
