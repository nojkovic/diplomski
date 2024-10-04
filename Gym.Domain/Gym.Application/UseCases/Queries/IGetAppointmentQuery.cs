﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.CoachTraining;

namespace Gym.Application.UseCases.Queries
{
    public interface IGetAppointmentQuery : IQuery<ResponseAppointmentDTO, int>
    {
    }
}
