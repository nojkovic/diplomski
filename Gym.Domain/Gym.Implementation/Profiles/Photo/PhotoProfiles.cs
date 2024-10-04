using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.MembershipFee;
using Gym.Application.DTO.Photo;

namespace Gym.Implementation.Profiles.Photo
{
    public class PhotoProfiles : Profile
    {
        public PhotoProfiles()
        {
            CreateMap<Domain.Photo, ResponsePhotoDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
                .ForMember(x => x.Path, y => y.MapFrom(u => u.Path))
                .ForMember(x => x.GymId, y => y.MapFrom(u => u.GymId))
                .ForMember(x => x.LocationGym, y => y.MapFrom(u => u.Gym.Location.Address));



        }
    }
}
