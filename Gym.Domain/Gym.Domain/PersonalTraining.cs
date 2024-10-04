using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class PersonalTraining:Entity
    {
        public int NumberOfTerms {  get; set; }
        public decimal Price { get; set; }
    }
}
