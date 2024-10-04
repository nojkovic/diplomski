using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Gym;
using Gym.Application.UseCases.Commands.Gyms;
using Gym.DataAccess;
using Gym.Implementation.Validators.Gym;
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.Gyms
{
    public class EfDeleteGymCommand : EfUseCase, IDeleteGymCommand
    {
        private DeleteGymDTOValidator validator;
        public EfDeleteGymCommand(GymContext context, DeleteGymDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 59;

        public string Name => "Gym Delete";

        public void Execute(BaseGymDTO data)
        {
            validator.ValidateAndThrow(data);
            Domain.Gym g = Context.Gyms.Include(x => x.Photos)
                                       .Include(x => x.Reservations)
                                       .Include(x=>x.Coaches)
                                       .Include(x=>x.CoachTraining)
                                       .Include(x=>x.Appointments)
                                       .First(x => x.Id == data.Id);

            var gymPhotos = g.Photos;
            var gymReservation = g.Reservations;
            var gymCoaches = g.Coaches;
            var gymCoacheTrainings = g.CoachTraining;
            var gymAppointments = g.Appointments;

            foreach (var r in gymPhotos)
            {
                r.IsActive = false;

            }
            foreach (var r in gymReservation)
            {
                r.IsActive = false;

            }

            foreach (var r in gymCoaches)
            {
                r.IsActive = false;

            }

            foreach (var r in gymCoacheTrainings)
            {
                r.IsActive = false;

            }

            foreach (var r in gymAppointments)
            {
                r.IsActive = false;

            }

            g.IsActive = false;
            Context.SaveChanges();
        }
    }
}
