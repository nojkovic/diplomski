using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.Coach;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Appointment
{
    public class EfGetAppointmentQuery : EfFindUseCase<ResponseAppointmentDTO, Domain.Appointment>, IGetAppointmentQuery
    {
        public EfGetAppointmentQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id => 55;

        public override string Name => "Appointment Search";

    }
}
