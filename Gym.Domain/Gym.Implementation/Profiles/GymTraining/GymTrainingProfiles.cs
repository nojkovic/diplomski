using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.Gym;
using Gym.Application.DTO.GymTraining;

namespace Gym.Implementation.Profiles.GymTraining
{
    public class GymTrainingProfiles : Profile
    {
        public GymTrainingProfiles()
        {
            CreateMap<Domain.GymTraining, ResponseGymTrainingDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
                .ForMember(x => x.TrainingId, y => y.MapFrom(u => u.TrainingId))
                .ForMember(x => x.Training, y => y.MapFrom(u => new TrainingRes
                {
                    Id = u.Training.Id,
                    TrainingType = u.Training.TrainingType,
                }))
                .ForMember(x => x.Gym, y => y.MapFrom(u => new GymDTO
                {
                    Id = u.Gym.Id,
                    Contact = u.Gym.Contact,
                    Description = u.Gym.Description,
                    LocationId = u.Gym.LocationId,
                    Name = u.Gym.Name,
                }));

        }
    }
}
