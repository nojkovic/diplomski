using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.DTO.Gym;

namespace Gym.Implementation.Profiles.CoachTraining
{
    public class CoachTrainingProfiles : Profile
    {
        public CoachTrainingProfiles()
        {
            CreateMap<Domain.CoachTraining, ResponseCoachTrainingDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
                .ForMember(x => x.CoachId, y => y.MapFrom(u => u.CoachId))
                .ForMember(x => x.TrainingId, y => y.MapFrom(u => u.TrainingId))
                .ForMember(x => x.Coach, y => y.MapFrom(u => new CoachR
                {
                    Id=u.Coach.Id,
                    CoachName=u.Coach.Name,
                    CoachLastName=u.Coach.LastName
                }))
                .ForMember(x => x.Training, y => y.MapFrom(u => new TrainingR
                {
                    Id = u.Training.Id,
                    TrainingType = u.Training.TrainingType,
                    
                }))
                .ForMember(x => x.Gym, y => y.MapFrom(u => new GymDTO
                {
                    Id = u.Gym.Id,
                    Contact=u.Gym.Contact,
                    Description=u.Gym.Description,
                    LocationId=u.Gym.LocationId,
                    Name = u.Gym.Name,
                    

                }));

        }
    }
}
