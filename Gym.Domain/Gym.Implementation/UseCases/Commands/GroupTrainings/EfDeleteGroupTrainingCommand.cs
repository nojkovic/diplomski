using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.UseCases.Commands.GroupTrainings;
using Gym.Application.UseCases.Commands.MembershipFees;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.GroupTraining;
using Gym.Implementation.Validators.MembershipFee;

namespace Gym.Implementation.UseCases.Commands.GroupTrainings
{
    public class EfDeleteGroupTrainingCommand : EfUseCase, IDeleteGroupTrainingCommand
    {
        private DeleteGroupTrainingDTOValidator validator;
        public EfDeleteGroupTrainingCommand(GymContext context, DeleteGroupTrainingDTOValidator _validator) : base(context)
        {
            this.validator = _validator;
        }

        public int Id => 14;

        public string Name => "GroupTraining Delete";

        public void Execute(BaseGroupTrainingDTO data)
        {
            validator.ValidateAndThrow(data);
            GroupTraining gt = Context.GroupTrainings.First(x => x.Id == data.Id);

            gt.IsActive = false;
            Context.SaveChanges();
        }
    }
}
