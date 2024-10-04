using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.UseCases.Commands.CoachTrainings;
using Gym.DataAccess;
using Gym.Implementation.Validators.CoachTraining;
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.CoachTrainings
{
    public class EfDeleteCoachTrainingCommand : EfUseCase, IDeleteCoachTrainingCommand
    {
        private DeleteCoachTrainingDTOValidator validator;
        public EfDeleteCoachTrainingCommand(GymContext context, DeleteCoachTrainingDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id =>49;

        public string Name =>"CoachTraining Delete";

        public void Execute(BaseCoachTrainingDTO data)
        {
            validator.ValidateAndThrow(data);
            Domain.CoachTraining ct = Context.CoachTrainings.Include(x => x.Appointments)
                                                            .First(x => x.Id == data.Id);

            var coachtrainingApp = ct.Appointments;

            foreach (var r in coachtrainingApp)
            {
                r.IsActive = false;

            }
           
            ct.IsActive = false;
            Context.SaveChanges();
        }
    }
}
