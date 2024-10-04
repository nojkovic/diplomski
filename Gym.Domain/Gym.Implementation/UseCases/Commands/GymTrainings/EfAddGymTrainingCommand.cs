using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.GymTraining;
using Gym.Application.UseCases.Commands.CoachTrainings;
using Gym.Application.UseCases.Commands.GymTraining;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.CoachTraining;
using Gym.Implementation.Validators.GymTraining;

namespace Gym.Implementation.UseCases.Commands.GymTrainings
{
    public class EfAddGymTrainingCommand : EfUseCase, IAddGymTrainingCommand
    {
        private AddGymTrainingDTOValidator validator;
        public EfAddGymTrainingCommand(GymContext context, AddGymTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 76;

        public string Name => "Gym training add";

        public void Execute(GymTrainingDTO data)
        {
            validator.ValidateAndThrow(data);

            GymTraining gt = new GymTraining
            {
              
                TrainingId = data.TrainingId,
                GymId = data.GymId,

            };

            Context.GymTrainings.Add(gt);
            Context.SaveChanges();
        }
    }
}
