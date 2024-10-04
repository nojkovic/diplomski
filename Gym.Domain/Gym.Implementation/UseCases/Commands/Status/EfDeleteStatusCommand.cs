using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Status;
using Gym.Application.UseCases.Commands.Status;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.Status;
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.Status
{
    public class EfDeleteStatusCommand : EfUseCase, IDeleteStatusCommand
    {
        private DeleteStatusDTOValidator validator;
        public EfDeleteStatusCommand(GymContext context, DeleteStatusDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 29;

        public string Name => "Status Delete";

        public void Execute(BaseStatusDTO data)
        {
            validator.ValidateAndThrow(data);
            Domain.Status st = Context.Status.Include(x => x.Reservations)
                                    .First(x => x.Id == data.Id);

            var statusReservation = st.Reservations;

            foreach (var r in statusReservation)
            {
                r.IsActive = false;

            }
            st.IsActive = false;
            Context.SaveChanges();
        }
    }
}
