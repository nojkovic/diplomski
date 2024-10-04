using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Photo;
using Gym.Domain;

namespace Gym.Implementation.Profiles.Coach
{
    public class CoachProfiles : Profile
    {
        public CoachProfiles() 
        {
            CreateMap<Domain.Coach, ResponseCoachDTO>()
            .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
            .ForMember(x => x.LastName, y => y.MapFrom(u => u.LastName))
            .ForMember(x => x.Description, y => y.MapFrom(u => u.Description))
            .ForMember(x => x.Photo, y => y.MapFrom(u => u.Photo))
            .ForMember(x => x.GymId, y => y.MapFrom(u => u.GymId))
            .ForMember(x => x.Trainings, y => y.MapFrom(u => u.CoachTrainings
                .Where(v => v.IsActive)
                .Select(v => new CoachTrainingDtoResponse
                {
                    Id = v.Id,
                    CoachId = v.CoachId,
                    TrainingId = v.TrainingId,
                    Training = new TrainingDto
                    {
                        Id = v.Training.Id,
                        TypeOfTraining = v.Training.TrainingType
                    
                    }
                })));


        }
    }
}
