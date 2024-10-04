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
using Gym.Implementation.Validators.CoachTraining;
using Gym.Implementation.Validators.GymTraining;
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.GymTrainings
{
    public class EfDeleteGymTrainingCommand : EfUseCase, IDeleteGymTrainingCommand
    {
        private DeleteGymTrainingDTOValidator validator;
        public EfDeleteGymTrainingCommand(GymContext context, DeleteGymTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 78;

        public string Name => "Gym training delete";

        public void Execute(BaseGymTrainingDTO data)
        {
            validator.ValidateAndThrow(data);
            Domain.GymTraining gt = Context.GymTrainings.First(x => x.Id == data.Id);
           
            gt.IsActive = false;
            Context.SaveChanges();
        }
    }
}
