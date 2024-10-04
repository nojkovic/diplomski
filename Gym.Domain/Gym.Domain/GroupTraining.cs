using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class GroupTraining:Entity
    {
        public string TypeOfTraining { get; set; }
        public string Description { get; set; }
        public decimal PricePerTerm { get; set; }
    }
}
