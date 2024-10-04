using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO;
using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.Coach;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Appointment
{
    public class EfGetAppointmentsQuery : EfUseCase, IGetAppointmentsQuery
    {
        private readonly IMapper _mapper;
        public EfGetAppointmentsQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id =>56;

        public string Name => "Appointments Search";

        public PagedResponse<ResponseAppointmentDTO> Execute(SearchAppointment search)
        {
            var query = Context.Appointments.Where(x => x.IsActive).AsQueryable();


            if (search.CoachTrainingId.HasValue)
            {
                query = query.Where(x => x.CoachTrainingId==search.CoachTrainingId);
            }
            if (search.GymId.HasValue)
            {
                query = query.Where(x => x.GymId == search.GymId);
            }
            var groupt = query.ToList();

            return query.AsPagedReponse<Domain.Appointment, ResponseAppointmentDTO>(search, _mapper);
        }
    }
}
