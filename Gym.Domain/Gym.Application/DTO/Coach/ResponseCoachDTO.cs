using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Domain;

namespace Gym.Application.DTO.Coach
{
    public class ResponseCoachDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Photo {  get; set; }
        public int GymId { get; set; }  
        public IEnumerable<CoachTrainingDtoResponse> Trainings { get; set; }

    }
    public class CoachTrainingDtoResponse
    {
        public int Id { get; set; }
        public int CoachId { get; set; }
        public int TrainingId { get; set; }
        //public ResponseCoachDTO Coach { get; set; }
        public TrainingDto Training { get; set; }
    }
    public class TrainingDto
    {
        public int Id { get; set; }
        public string TypeOfTraining { get; set; }
        public int TrainingId { get; set; }
    }
}
