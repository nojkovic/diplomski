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
    public class EffAddPersonalTrainingCommand : EfUseCase, IAddPersonalTrainingCommand
    {
        private AddPersonalTrainingDTOValidator validator;
        public EffAddPersonalTrainingCommand(GymContext context, AddPersonalTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id =>17;

        public string Name => "PersonalTraining Add";

        public void Execute(PersonalTrainingDTO data)
        {
            validator.ValidateAndThrow(data);

            PersonalTraining pt = new PersonalTraining
            {
                NumberOfTerms = data.NumberOfTerms,
                Price = data.Price,

            };

            Context.PersonalTrainings.Add(pt);
            Context.SaveChanges();


        }
    }
}
