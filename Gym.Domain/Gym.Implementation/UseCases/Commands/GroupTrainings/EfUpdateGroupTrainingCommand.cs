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
    public class EfUpdateGroupTrainingCommand : EfUseCase, IUpdateGroupTrainingCommand
    {
        private UpdateGroupTrainingDTOValidator validator;
        public EfUpdateGroupTrainingCommand(GymContext context, UpdateGroupTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 13;

        public string Name => "GroupTraining Update";

        public void Execute(UpdateGroupTrainingDTO data)
        {
            validator.ValidateAndThrow(data);
            GroupTraining gt = Context.GroupTrainings.First(x => x.Id == data.Id);
            gt.TypeOfTraining=data.TypeOfTraining;
            gt.Description = data.Description;
            gt.PricePerTerm = data.PricePerTerm;
            gt.IsActive = true;


            Context.SaveChanges();
        }
    }
}
