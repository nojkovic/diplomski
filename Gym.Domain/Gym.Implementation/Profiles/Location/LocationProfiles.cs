using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Location;
using Gym.Application.DTO.MembershipFee;

namespace Gym.Implementation.Profiles.Location
{
    public class LocationProfiles : Profile
    {
        public LocationProfiles()
        {
            CreateMap<Domain.Location, ResponseLocationDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
                .ForMember(x => x.Address, y => y.MapFrom(u => u.Address))
                .ForMember(x => x.City, y => y.MapFrom(u => u.City));



        }
    }
}
