using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Gym;
using Gym.Application.DTO.Rating;
using Gym.Application.DTO.Reservation;
using Gym.Domain;

namespace Gym.Implementation.Profiles.Ratings
{
    internal class RatingProfiles : Profile
    {
        public RatingProfiles()
        {
            CreateMap<Rating, ResponseRatingDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
                .ForMember(x => x.Rate, y => y.MapFrom(u => u.Rate))
                .ForMember(x => x.UserId, y => y.MapFrom(u => u.UserId))
                .ForMember(x => x.GymId, y => y.MapFrom(u => u.GymId))
                .ForMember(x => x.Message, y => y.MapFrom(u => u.Message))
                .ForMember(x => x.User, y => y.MapFrom(u => new ResponseBaseUser
                {
                    Id = u.User.Id,
                    Name = u.User.Name,
                    LastName = u.User.LastName,
                    Email = u.User.Email,
         
                }))
                .ForMember(x => x.Gym, y => y.MapFrom(u => new GymDTO
                {
                    Id = u.Gym.Id,
                    Name = u.Gym.Name,
                    WorkingTime = u.Gym.WorkingTime,
                    WorkingTimeOnWeekend = u.Gym.WorkingTimeOnWeekend,
                    Description = u.Gym.Description,
                    
                }));

        }
    }
}
