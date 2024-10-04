using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.PersonalTraining;
using Gym.Application.UseCases.Commands.PersonalTrainings;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.PersonalTraining;

namespace Gym.Implementation.UseCases.Commands.PersonalTrainings
{
    public class EfDeletePersonalTrainingCommand : EfUseCase, IDeletePersonalTrainingCommand
    {
        private DeletePersonalTrainingDTOValidator validator;
        public EfDeletePersonalTrainingCommand(GymContext context, DeletePersonalTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 19;

        public string Name => "PersonalTraining Delete";

        public void Execute(BasePersonalTrainingDTO data)
        {
            validator.ValidateAndThrow(data);
            PersonalTraining pt = Context.PersonalTrainings.First(x => x.Id == data.Id);

            pt.IsActive = false;
            Context.SaveChanges();
        }
    }
}
