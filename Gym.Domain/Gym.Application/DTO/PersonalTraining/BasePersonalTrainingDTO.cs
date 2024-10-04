using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.PersonalTraining
{
    public class BasePersonalTrainingDTO
    {
        public int Id { get; set; }
        public int NumberOfTerms { get; set; }
        public decimal Price { get; set; }
    }
}
