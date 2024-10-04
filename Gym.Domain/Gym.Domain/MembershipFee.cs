using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class MembershipFee:Entity
    {
        public string TypeOfMembership { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }  
    }
}
