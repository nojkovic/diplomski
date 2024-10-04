using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.Gym;

namespace Gym.Implementation.Profiles.Gym
{
    public class GymProfiles : Profile
    {
        public GymProfiles()
        {
            CreateMap<Domain.Gym, ResponseGymDTO>()
            .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
            .ForMember(x => x.Contact, y => y.MapFrom(u => u.Contact))
            .ForMember(x => x.WorkingTimeOnWeekend, y => y.MapFrom(u => u.WorkingTimeOnWeekend))
            .ForMember(x => x.WorkingTime, y => y.MapFrom(u => u.WorkingTime))
            .ForMember(x => x.Description, y => y.MapFrom(u => u.Description))
            .ForMember(x => x.LocationId, y => y.MapFrom(u => u.LocationId))
            .ForMember(x => x.Location, y => y.MapFrom(u => new ResponseLocation
            {
                Id=u.Location.Id,
                Address=u.Location.Address,
                City=u.Location.City,
            }))
            .ForMember(x => x.Appointment, y => y.MapFrom(u => u.Appointments
                .Where(v => v.IsActive)
                .Select(v => new AppointmentRes
                {
                   Id = v.Id,
                   Date = v.Date,
                   Time = v.Time,
                   CoachTrainingId = v.CoachTrainingId,
                   CoachTraining=new ResponseCoachTrai
                   {
                       Id = v.CoachTraining.Id,
                       CoachId = v.CoachTraining.CoachId,
                       TrainingId = v.CoachTraining.TrainingId,
                       Coach = new ResponseCoach
                       {
                           Id = v.CoachTraining.Coach.Id,
                           Name = v.CoachTraining.Coach.Name,
                           LastName = v.CoachTraining.Coach.LastName
                       },
                       Training = new ResponseTraining
                       {
                           Id = v.CoachTraining.Training.Id,
                           TrainingType = v.CoachTraining.Training.TrainingType
                       }
                   }

                })))
            .ForMember(x => x.Photos, y => y.MapFrom(u => u.Photos
                .Where(v => v.IsActive)
                .Select(v => new PhotoDto
                {
                    Path=v.Path,
                    
                })))
             .ForMember(x => x.Coaches, y => y.MapFrom(u => u.Coaches
                .Where(v => v.IsActive)
                .Select(v => new CoachDTO
                {
                    Id = v.Id,
                    Name = v.Name,
                    LastName = v.LastName,
                    Description = v.Description,
                    Photo = v.Photo,
                    GymId = v.GymId,
                    TrainingIds = u.CoachTraining
                        .Where(ct => ct.CoachId == v.Id)
                        .Select(ct => ct.TrainingId)
                        .ToList()
                })));


            CreateMap<Domain.Gym, ResponseGymsDTO>()
            .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
            .ForMember(x => x.Contact, y => y.MapFrom(u => u.Contact))
            .ForMember(x => x.WorkingTimeOnWeekend, y => y.MapFrom(u => u.WorkingTimeOnWeekend))
            .ForMember(x => x.WorkingTime, y => y.MapFrom(u => u.WorkingTime))
            .ForMember(x => x.Description, y => y.MapFrom(u => u.Description))
            .ForMember(x => x.LocationId, y => y.MapFrom(u => u.LocationId))
            .ForMember(x => x.Location, y => y.MapFrom(u => new ResponseLocation
            {
                Id = u.Location.Id,
                Address = u.Location.Address,
                City = u.Location.City,
            }))
            //.ForMember(x => x.Appointment, y => y.MapFrom(u => u.Appointments
            //    .Where(v => v.IsActive)
            //    .Select(v => new AppointmentRes
            //    {
            //        Id = v.Id,
            //        Date = v.Date,
            //        Time = v.Time,
            //        CoachTrainingId = v.CoachTrainingId,
            //        CoachTraining = new ResponseCoachTrai
            //        {
            //            Id = v.CoachTraining.Id,
            //            CoachId = v.CoachTraining.CoachId,
            //            TrainingId = v.CoachTraining.TrainingId,
            //            Coach = new ResponseCoach
            //            {
            //                Id = v.CoachTraining.Coach.Id,
            //                Name = v.CoachTraining.Coach.Name,
            //                LastName = v.CoachTraining.Coach.LastName
            //            },
            //            Training = new ResponseTraining
            //            {
            //                Id = v.CoachTraining.Training.Id,
            //                TrainingType = v.CoachTraining.Training.TrainingType
            //            }
            //        }

            //    })))
            .ForMember(x => x.Photos, y => y.MapFrom(u => u.Photos
                .Where(v => v.IsActive)
                .Select(v => new PhotoDto
                {
                    Path = v.Path,

                })))
             .ForMember(x => x.Coaches, y => y.MapFrom(u => u.Coaches
                .Where(v => v.IsActive)
                .Select(v => new CoachDTO
                {
                    Id = v.Id,
                    Name = v.Name,
                    LastName = v.LastName,
                    Description = v.Description,
                    Photo = v.Photo,
                    GymId = v.GymId
                })));

        }
    }
}
