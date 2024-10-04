using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.Gym;

namespace Gym.Application.DTO.GymTraining
{
    public class ResponseGymTrainingDTO
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int GymId { get; set; }
        public TrainingRes Training { get; set; }
        public GymDTO Gym { get; set; }
    }

    public class TrainingRes
    {
        public int Id { get; set; }
        public string TrainingType { get; set; }
    }
}
