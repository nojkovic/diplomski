using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Reservation;
using Gym.Application.DTO.Status;
using Gym.DataAccess;
using Gym.Implementation.Validators.Status;

namespace Gym.Implementation.Validators.Reservation
{
    public class UpdateReservationDTOValidator : ReservationBaseValidator<UpdateReservationDTO>
    {
        public UpdateReservationDTOValidator(GymContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.Reservations.Any(u => u.Id == x))
             .WithMessage("Id must exists");
            RuleFor(x => x.StatusId).Must(x => ctx.Status.Any(u => u.Id == x))
                .WithMessage("StatusId must exists").NotEmpty();
        }
    }
}
