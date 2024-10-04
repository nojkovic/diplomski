using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Gym;
using Gym.Application.DTO.Reservation;
using Gym.Application.DTO.Status;
using Gym.Application.DTO.User;

namespace Gym.Implementation.Profiles.Reservation
{
    public class ReservationProfiles : Profile
    {
        public ReservationProfiles()
        {
            CreateMap<Domain.Reservation, ResponseReservationDTO>()
               .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
               .ForMember(x => x.UserId, y => y.MapFrom(u => u.UserId))
               .ForMember(x => x.GymId, y => y.MapFrom(u => u.GymId))
               .ForMember(x => x.CoachId, y => y.MapFrom(u => u.CoachId))
               .ForMember(x => x.AppointmentId, y => y.MapFrom(u => u.AppointmentId))
               .ForMember(x => x.StatusId, y => y.MapFrom(u => u.StatusId))
               .ForMember(x=>x.ResponseUser,y=>y.MapFrom(c=>new ResponseUser
               {
                   Id=c.User.Id,
                   Email=c.User.Email,
                   Name=c.User.Name,
                   LastName=c.User.LastName,
               }))
               .ForMember(x => x.ResponseGym, y => y.MapFrom(c => new ResponseGym
               {
                   Id = c.Gym.Id,
                   WorkingTime = c.Gym.WorkingTime,
                   WorkingTimeOnWeekend=c.Gym.WorkingTimeOnWeekend,
                   Description = c.Gym.Description,
                   Name=c.Gym.Name,
                   Location = new ResponseLoc
                   {
                       Id = c.Gym.Location.Id,
                       Address = c.Gym.Location.Address,
                       City = c.Gym.Location.City,
                   }
               }))
               .ForMember(x => x.ResponseCoach, y => y.MapFrom(c => new Application.DTO.Reservation.ResponseCoach
               {
                    Id = c.Coach.Id,
                    Name=c.Coach.Name,
                    LastName = c.Coach.LastName
               }))
               .ForMember(x => x.ResponseAppointment, y => y.MapFrom(c => new ResponseAppointment
               {
                   Id = c.Appointment.Id,
                   Date = c.Appointment.Date,
                   Time = c.Appointment.Time,
                   CoachTrainings = new ResponseCoachTrainings
                   {
                       Id = c.Appointment.CoachTraining.Id,
                       Coach = new Application.DTO.Reservation.ResponseCoach
                       {
                           Id = c.Appointment.CoachTraining.Coach.Id,
                           Name = c.Appointment.CoachTraining.Coach.Name,
                           LastName = c.Appointment.CoachTraining.Coach.LastName
                       },
                      Training=new Application.DTO.Reservation.ResponseTraining
                      {
                          Id=c.Appointment.CoachTraining.Training.Id,
                          TypeOfTraining=c.Appointment.CoachTraining.Training.TrainingType
                      },
                   }
               }))
               .ForMember(x => x.ResponseStatus, y => y.MapFrom(c => new ResponseStatus
               {
                   Id = c.Status.Id,
                   Status = c.Status.Name,
                  
               }));



            
           
        }
    }
}
