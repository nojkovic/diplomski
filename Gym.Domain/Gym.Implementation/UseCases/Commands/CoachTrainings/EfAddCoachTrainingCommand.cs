using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.UseCases.Commands.CoachTrainings;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.CoachTraining;

namespace Gym.Implementation.UseCases.Commands.CoachTrainings
{
    public class EfAddCoachTrainingCommand : EfUseCase, IAddCoachTrainingCommand
    {
        private AddCoachTrainingDTOValidator validator;
        public EfAddCoachTrainingCommand(GymContext context, AddCoachTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id =>47;

        public string Name => "CoachTraining Add";

        public void Execute(CoachTrainingDTO data)
        {
            validator.ValidateAndThrow(data);

            CoachTraining ct = new CoachTraining
            {
                CoachId = data.CoachId,
                TrainingId = data.TrainingId,
                GymId = data.GymId,

            };

            Context.CoachTrainings.Add(ct);
            Context.SaveChanges();
        }
    }
}
