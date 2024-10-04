using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.Coach;
using Gym.DataAccess;
using Gym.Implementation.Validators.Coach;

namespace Gym.Implementation.Validators.Appointment
{
    public class AddAppointmentDTOValidator : AppointmentBaseValidator<AppointmentDTO>
    {
        public AddAppointmentDTOValidator(GymContext ctx) : base(ctx)
        {
        }
    }
}
