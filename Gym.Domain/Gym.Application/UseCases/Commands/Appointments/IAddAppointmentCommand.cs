using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.Coach;

namespace Gym.Application.UseCases.Commands.Appointments
{
    public interface IAddAppointmentCommand : ICommand<AppointmentDTO>
    {
    }
}
