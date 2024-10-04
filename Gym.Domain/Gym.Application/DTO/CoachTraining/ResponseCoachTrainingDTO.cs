using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Coach;
using Gym.Application.DTO.Gym;

namespace Gym.Application.DTO.CoachTraining
{
    public class ResponseCoachTrainingDTO
    {
        public int Id { get; set; }
        public int CoachId { get; set; }
        public int TrainingId { get; set; }
        public int GymId { get; set; }
        public CoachR Coach { get; set; }
        public TrainingR Training { get; set; }
        public GymDTO Gym { get; set; }
    }

    public class CoachR
    {
        public int Id { get; set; }
        public string CoachName { get; set; }
        public string CoachLastName { get; set; }

    }
    public class TrainingR
    {
        public int Id { get; set; }
        public string TrainingType { get;set; }
    }
}
