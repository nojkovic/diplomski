using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Gym;
using Gym.Application.DTO.Reservation;

namespace Gym.Application.DTO.Appointment
{
    public class ResponseAppointmentDTO
    {
        public int Id { get; set; }
        public int CoachTrainingId { get; set; }
        public int GymId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public ResponseCoachTrai CoachTraining { get; set; }
        public ResponseGym Gym { get; set; }


    }

    public class ResponseCoachTrai
    {
        public int Id { get; set; }
        public int CoachId { get; set; }
        public int TrainingId { get; set; }
        public ResponseCoach Coach { get; set; }
        public ResponseTraining Training { get; set; }
    }

    public class ResponseTraining
    {
        public int Id { get; set; }
        public string TrainingType { get; set; }
    }

    public class ResponseCoach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
