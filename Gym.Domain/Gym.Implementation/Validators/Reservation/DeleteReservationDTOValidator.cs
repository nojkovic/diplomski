using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Reservation;
using Gym.Application.DTO.Status;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Reservation
{
    public class DeleteReservationDTOValidator : AbstractValidator<BaseReservationDTO>
    {
        public DeleteReservationDTOValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).Must(x => ctx.Reservations.Any(u => u.Id == x))
                .WithMessage("Id must exists");

        }
    }
}
