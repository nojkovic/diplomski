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
    public class EfAddTrainingCommand : EfUseCase, IAddTrainingCommand
    {
        private AddTrainingDTOValidator validator;
        public EfAddTrainingCommand(GymContext context, AddTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 42;

        public string Name => "Training Add";

        public void Execute(TrainingDTO data)
        {
            validator.ValidateAndThrow(data);

            Domain.Training t = new Domain.Training
            {
                TrainingType=data.TrainingType,
                TrainingTypeId=data.TrainingTypeId
            };

            Context.Trainings.Add(t);
            Context.SaveChanges();
        }
    }
}
