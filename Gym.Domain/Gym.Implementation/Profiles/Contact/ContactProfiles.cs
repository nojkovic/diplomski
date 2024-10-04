using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Contact;

namespace Gym.Implementation.Profiles.Contact
{
    public class ContactProfiles : Profile
    {
        public ContactProfiles()
        {
            CreateMap<Domain.Contact, ResponseContact>()
           .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
           .ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
           .ForMember(x => x.Email, y => y.MapFrom(u => u.Email))
           .ForMember(x => x.Message, y => y.MapFrom(u => u.Message))
           .ForMember(x => x.Subject, y => y.MapFrom(u => u.Subject));
        }
    }
}
