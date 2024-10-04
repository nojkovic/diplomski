using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Gym;
using Gym.Application.DTO.Reservation;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Reservation
{
    public class ReservationBaseValidator<T> : AbstractValidator<T>
        where T : BaseReservationDTO
    {
        public ReservationBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            
            RuleFor(x => x.UserId).Must(x => ctx.Users.Any(u => u.Id == x))
                .WithMessage("UserId must exists").NotEmpty();
            RuleFor(x => x.GymId).Must(x => ctx.Gyms.Any(u => u.Id == x))
                .WithMessage("GymId must exists").NotEmpty();
            RuleFor(x => x.CoachId).Must(x => ctx.Coachs.Any(u => u.Id == x))
                .WithMessage("CoachId must exists").NotEmpty();
            RuleFor(x => x.AppointmentId).Must(x => ctx.Appointments.Any(u => u.Id == x))
                .WithMessage("AppointmentId must exists").NotEmpty();
            
           



        }

    }
}
