using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application;
using Gym.Application.DTO;
using Gym.Application.DTO.PersonalTraining;
using Gym.Application.DTO.Reservation;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Queries.Reservation
{
    public class EfGetReservationsQuery : EfUseCase, IGetReservationsQuery
    {
        private readonly IMapper _mapper;
        private IApplicationActor _actor;
        public EfGetReservationsQuery(GymContext context, IMapper mapper, IApplicationActor actor) : base(context)
        {
            _mapper = mapper;
            _actor = actor;
        }

        public int Id => 66;

        public string Name => "Reservations Search";

        public PagedResponse<ResponseReservationDTO> Execute(SearchReservation search)
        {
            var query = Context.Reservations.Where(x => x.IsActive)
                                            .Include(x=>x.User)
                                            .Include(z=>z.Gym)
                                            .ThenInclude(x=>x.Location)
                                            .Include(c=>c.Coach)
                                            .Include(c=>c.Status).AsQueryable();

            search.UserId=_actor.Id;


            if (!string.IsNullOrEmpty(search.UserEmail))
            {
                query = query.Where(x => x.User.Email.ToLower().Contains(search.UserEmail.ToLower()));
            }

            if(search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }

            if (!string.IsNullOrEmpty(search.CoachName))
            {
                query = query.Where(x => x.Coach.Name.ToLower().Contains(search.CoachName.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.GymAdress))
            {
                query = query.Where(x => x.Gym.Location.Address.ToLower().Contains(search.GymAdress.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Status))
            {
                query = query.Where(x => x.Status.Name.ToLower().Contains(search.Status.ToLower()));
            }
            var r = query.ToList();

            return query.AsPagedReponse<Domain.Reservation, ResponseReservationDTO>(search, _mapper);
        }
    }
}
