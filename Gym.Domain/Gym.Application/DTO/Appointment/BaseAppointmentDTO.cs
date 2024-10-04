using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.Appointment
{
    public class BaseAppointmentDTO
    {
        public int Id { get; set; }
        public int CoachTrainingId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int GymId { get; set; }
    }
}
