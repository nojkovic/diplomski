using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.PersonalTraining;
using Gym.Application.DTO.Reservation;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Reservation
{
    public class EfGetReservationQuery : EfFindUseCase<ResponseReservationDTO, Domain.Reservation>, IGetReservationQuery
    {
        public EfGetReservationQuery(GymContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override int Id => 65;

        public override string Name => "Reservation Search";
    }
}
