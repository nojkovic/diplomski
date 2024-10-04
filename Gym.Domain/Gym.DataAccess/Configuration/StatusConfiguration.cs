using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Configuration
{
    public class StatusConfiguration : NamedEntityConfiguration<Status>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Status> builder)
        {
           
        }
    }
}
