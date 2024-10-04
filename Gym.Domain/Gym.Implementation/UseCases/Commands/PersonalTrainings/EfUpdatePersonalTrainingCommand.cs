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
    public class EfUpdatePersonalTrainingCommand : EfUseCase, IUpdatePersonalTraining
    {
        private UpdatePersonalTrainingDTOValidator validator;
        public EfUpdatePersonalTrainingCommand(GymContext context, UpdatePersonalTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 18;

        public string Name => "PersonalTraining Update";

        public void Execute(UpdatePersonalTrainingDTO data)
        {
            validator.ValidateAndThrow(data);
            PersonalTraining pt = Context.PersonalTrainings.First(x => x.Id == data.Id);
            pt.NumberOfTerms=data.NumberOfTerms;
            pt.Price= data.Price;
            pt.IsActive = true;


            Context.SaveChanges();
        }
    }
}
