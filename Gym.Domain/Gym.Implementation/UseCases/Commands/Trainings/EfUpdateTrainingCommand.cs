using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Training;
using Gym.Application.UseCases.Commands.Trainings;
using Gym.DataAccess;
using Gym.Implementation.Validators.Training;

namespace Gym.Implementation.UseCases.Commands.Trainings
{
    public class EfUpdateTrainingCommand : EfUseCase, IUpdateTrainingCommand
    {
        private UpdateTrainingDTOValidator validator;
        public EfUpdateTrainingCommand(GymContext context, UpdateTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 43;
        public string Name =>"Training Update";

        public void Execute(UpdateTrainingDTO data)
        {
            validator.ValidateAndThrow(data);
            Domain.Training t = Context.Trainings.First(x => x.Id == data.Id);
            t.TrainingType = data.TrainingType;
            t.TrainingTypeId = data.TrainingTypeId;
            t.IsActive = true;


            Context.SaveChanges();
        }
    }
}
