using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Coach;
using Gym.Application.UseCases.Commands.Coach;
using Gym.DataAccess;
using Gym.Implementation.Validators.Coach;
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.Coachs
{
    public class EfDeleteCoachCommand : EfUseCase, IDeleteCoachCommand
    {
        private DeleteCoachDTOValidator validator;
        public EfDeleteCoachCommand(GymContext context, DeleteCoachDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 39;

        public string Name => "Coach Delete";

        public void Execute(BaseCoachDTO data)
        {
            validator.ValidateAndThrow(data);
            Domain.Coach ch = Context.Coachs.Include(x => x.Reservations)
                                            .Include(x => x.CoachTrainings)
                                            .First(x => x.Id == data.Id);

            var coachReservation = ch.Reservations;
            var coachTrainings=ch.CoachTrainings;

            foreach (var r in coachReservation)
            {
                r.IsActive = false;

            }
            foreach (var r in coachTrainings)
            {
                r.IsActive = false;

            }
            ch.IsActive = false;
            Context.SaveChanges();
        }
    }
}
