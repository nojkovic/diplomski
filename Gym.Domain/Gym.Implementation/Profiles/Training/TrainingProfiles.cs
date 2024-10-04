using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Status;
using Gym.Application.DTO.Training;

namespace Gym.Implementation.Profiles.Training
{
    public class TrainingProfiles : Profile
    {
        public TrainingProfiles()
        {
            CreateMap<Domain.Training, ResponseTrainingDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
                .ForMember(x => x.TrainingType, y => y.MapFrom(u => u.TrainingType))
                .ForMember(x => x.TrainingTypeId, y => y.MapFrom(u => u.TrainingTypeId));



        }
    }
}
