using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.UseCases.Commands.Coach;
using Gym.Application.UseCases.Commands.CoachTrainings;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.CoachTraining;

namespace Gym.Implementation.UseCases.Commands.CoachTrainings
{
    public class EfUpdateCoachTrainingCommand : EfUseCase, IUpdateCoachTrainingCommand
    {
        private UpdateCoachTrainingDTOValidator validator;
        public EfUpdateCoachTrainingCommand(GymContext context, UpdateCoachTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 48;

        public string Name => "CoachTraining Update";

        public void Execute(UpdateCoachTrainingDTO data)
        {
            validator.ValidateAndThrow(data);
            CoachTraining ct = Context.CoachTrainings.First(x => x.Id == data.Id);
            ct.TrainingId = data.TrainingId;
            ct.CoachId = data.CoachId;
            ct.IsActive = true;
            ct.GymId = data.GymId;


            Context.SaveChanges();

        }
    }
}
