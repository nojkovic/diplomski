using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.Reservation
{
    public class ResponseReservationDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GymId { get; set; }
        public int CoachId { get; set; }
        public int AppointmentId { get; set; }
        public int StatusId { get; set; }

        public ResponseUser ResponseUser { get; set; }
        public ResponseGym ResponseGym { get; set; }
        public ResponseCoach ResponseCoach { get; set; }
        public ResponseAppointment ResponseAppointment { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
    public class ResponseUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
    public class ResponseGym
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WorkingTime { get; set; }
        public string WorkingTimeOnWeekend { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public ResponseLoc Location { get; set; }
    }

    public class ResponseLoc
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }

    public class ResponseCoach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public class ResponseAppointment
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int CoachTrainingId { get; set; }
        public ResponseCoachTrainings CoachTrainings { get; set; }

    }

    public class ResponseCoachTrainings
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
        public string TypeOfTraining { get; set; }
    }
    public class ResponseStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
      
    }
}
