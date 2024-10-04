using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.Reservation;

namespace Gym.Implementation.Profiles.Appointment
{
    public class AppointmentProfiles : Profile
    {
        public AppointmentProfiles()
        {
            CreateMap<Domain.Appointment, ResponseAppointmentDTO>()
             .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
             .ForMember(x => x.CoachTrainingId, y => y.MapFrom(u => u.CoachTrainingId))
             .ForMember(x => x.GymId, y => y.MapFrom(u => u.GymId))
             .ForMember(x => x.Gym, y => y.MapFrom(u => new ResponseGym
             {
                 Id=u.GymId,
                 Name=u.Gym.Name,
                 LocationId=u.Gym.LocationId,
                 Location=new ResponseLoc
                 {
                     Id=u.Gym.Location.Id,
                     Address=u.Gym.Location.Address,
                     City=u.Gym.Location.City
                 }
             }))
             .ForMember(x => x.Date, y => y.MapFrom(u => u.Date))
             .ForMember(x => x.Time, y => y.MapFrom(u => u.Time))
             .ForMember(x => x.CoachTraining, y => y.MapFrom(u => new ResponseCoachTrai
             {
                 Id=u.CoachTrainingId,
                 CoachId=u.CoachTraining.CoachId,
                 TrainingId=u.CoachTraining.TrainingId,
                 Coach =new Application.DTO.Appointment.ResponseCoach
                 {
                     Id=u.CoachTraining.Coach.Id,
                     Name=u.CoachTraining.Coach.Name,
                     LastName=u.CoachTraining.Coach.LastName
                 },  
                 Training=new Application.DTO.Appointment.ResponseTraining
                 {
                     Id=u.CoachTraining.Training.Id,
                     TrainingType=u.CoachTraining.Training.TrainingType
                 }
             }));

            

           

           

        }
    }
}
