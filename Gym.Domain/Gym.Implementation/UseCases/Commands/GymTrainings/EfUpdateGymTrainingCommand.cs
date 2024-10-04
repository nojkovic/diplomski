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
    public class EfUpdateGymTrainingCommand : EfUseCase, IUpdateGymTrainingCommand
    {
        private UpdateGymTrainingDTOValidator validator;
        public EfUpdateGymTrainingCommand(GymContext context, UpdateGymTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 77;

        public string Name => "Gym training update";

        public void Execute(UpdateGymTrainingDTO data)
        {
            validator.ValidateAndThrow(data);
            GymTraining ct = Context.GymTrainings.First(x => x.Id == data.Id);
            ct.TrainingId = data.TrainingId;
            ct.IsActive = true;
            ct.GymId = data.GymId;


            Context.SaveChanges();
        }
    }
}
