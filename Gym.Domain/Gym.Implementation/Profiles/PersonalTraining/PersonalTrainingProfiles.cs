using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.PersonalTraining;

namespace Gym.Implementation.Profiles.PersonalTraining
{
    public class PersonalTrainingProfiles : Profile
    {
        public PersonalTrainingProfiles()
        {
            CreateMap<Domain.PersonalTraining, ResponsePersonalTrainingDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
                .ForMember(x => x.NumberOfTerms, y => y.MapFrom(u => u.NumberOfTerms))
                .ForMember(x => x.Price, y => y.MapFrom(u => u.Price));



        }
    }
}
