using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Appointment;
using Gym.Application.DTO.Coach;

namespace Gym.Application.DTO.Gym
{
    public class ResponseGymDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string WorkingTime { get; set; }
        public string WorkingTimeOnWeekend { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }


        public ResponseLocation Location { get; set; }

        public IEnumerable<AppointmentRes> Appointment { get; set; } = new HashSet<AppointmentRes>();
        public IEnumerable<PhotoDto> Photos { get; set; }
        public IEnumerable<CoachDTO> Coaches { get; set; } = new HashSet<CoachDTO>();
    }

    public class ResponseGymsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string WorkingTime { get; set; }
        public string WorkingTimeOnWeekend { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }


        public ResponseLocation Location { get; set; }

        public IEnumerable<AppointmentRes> Appointment { get; set; } = new HashSet<AppointmentRes>();
        public IEnumerable<PhotoDto> Photos { get; set; }
        public IEnumerable<CoachDTO> Coaches { get; set; } = new HashSet<CoachDTO>();
    }
    public class AppointmentRes
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public int CoachTrainingId { get; set; }
        public ResponseCoachTrai CoachTraining { get; set; }
    }

    public class PhotoDto
    {
        public string Path { get; set; }
    }
    public class ResponseLocation
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
