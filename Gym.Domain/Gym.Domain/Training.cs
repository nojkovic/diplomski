using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain
{
    public class Training:Entity
    {
        public string TrainingType { get; set; }
        public int TrainingTypeId { get; set; }

        public virtual ICollection<CoachTraining> CoachTrainings { get; set; }=new HashSet<CoachTraining>();
        public virtual ICollection<GymTraining> GymTraining { get; set; } = new HashSet<GymTraining>();
    }
}
