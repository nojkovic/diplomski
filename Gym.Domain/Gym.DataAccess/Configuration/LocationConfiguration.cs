using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Configuration
{
    public class LocationConfiguration : EntityConfiguration<Location>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Location> builder)
        {
            builder.Property(x => x.Address)
                   .IsRequired()
                   .HasMaxLength(70);

            builder.Property(x => x.City)
                   .IsRequired()
                   .HasMaxLength(30);
        }
    }
}
