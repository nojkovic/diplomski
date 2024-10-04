using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.GroupTraining;
using Gym.Domain;

namespace Gym.Implementation.Profiles.GroupTraining
{
    public class GroupTrainingProfiles:Profile
    {
        public GroupTrainingProfiles()
        {
            CreateMap<Domain.GroupTraining, ResponseGroupTrainingDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
                .ForMember(x => x.TypeOfTraining, y => y.MapFrom(u => u.TypeOfTraining))
                .ForMember(x => x.Description, y => y.MapFrom(u => u.Description))
                .ForMember(x => x.PricePerTerm, y => y.MapFrom(u => u.PricePerTerm));



        }
    }
}
