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
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.Trainings
{
    public class EfDeleteTrainingCommand : EfUseCase, IDeleteTrainingCommand
    {
        private DeleteTrainingDTOValidator validator;
        public EfDeleteTrainingCommand(GymContext context, DeleteTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 44;

        public string Name => "Training Delete";

        public void Execute(BaseTrainingDTO data)
        {
            validator.ValidateAndThrow(data);
            Domain.Training t = Context.Trainings.Include(x => x.CoachTrainings)
                                    .First(x => x.Id == data.Id);

            var coachtraining = t.CoachTrainings;

            foreach (var r in coachtraining)
            {
                r.IsActive = false;

            }
            t.IsActive = false;
            Context.SaveChanges();
        }
    }
}
