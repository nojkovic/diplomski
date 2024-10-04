using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Reservation;
using Gym.Application.UseCases.Commands.Reservations;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.Reservation;

namespace Gym.Implementation.UseCases.Commands.Reservations
{
    public class EfDeleteReservationCommand : EfUseCase, IDeleteReservationCommand
    {
        private DeleteReservationDTOValidator validator;
        public EfDeleteReservationCommand(GymContext context, DeleteReservationDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 64;

        public string Name => "Reservation Delete";

        public void Execute(BaseReservationDTO data)
        {
            validator.ValidateAndThrow(data);
            Reservation r = Context.Reservations.First(x => x.Id == data.Id);

            r.IsActive = false;
            Context.SaveChanges();
        }
    }
}
