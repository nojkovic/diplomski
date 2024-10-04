using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.PersonalTraining;
using Gym.Application.DTO.Status;

namespace Gym.Implementation.Profiles.Status
{
    public class StatusProfiles : Profile
    {
        public StatusProfiles()
        {
            CreateMap<Domain.Status, ResponseStatusDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
                .ForMember(x => x.Name, y => y.MapFrom(u => u.Name));



        }
    }
}
