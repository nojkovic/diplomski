using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.GroupTraining
{
    public class BaseGroupTrainingDTO
    {
        public int Id { get; set; }
        public string TypeOfTraining { get; set; }
        public string Description { get; set; }
        public decimal PricePerTerm { get; set; }
    }
}
