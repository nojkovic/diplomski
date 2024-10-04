using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Gym;
using Gym.Application.DTO.Rating;
using Gym.Application.DTO.Reservation;
using Gym.Application.DTO.User;
using Gym.Domain;

namespace Gym.Implementation.Profiles.User
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<Domain.User, UserDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
                .ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
                .ForMember(x => x.LastName, y => y.MapFrom(u => u.LastName))
                .ForMember(x => x.Email, y => y.MapFrom(u => u.Email))
                .ForMember(x => x.Contact, y => y.MapFrom(u => u.Contact))
                .ForMember(x => x.IsActivated, y => y.MapFrom(u => u.IsActivated));


        }
    }
}
