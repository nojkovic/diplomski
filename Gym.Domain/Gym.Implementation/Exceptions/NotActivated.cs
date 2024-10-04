using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Implementation.Exceptions
{
    public class NotActivated : Exception
    {
        public NotActivated(string message) : base(message) { }
    }
}
