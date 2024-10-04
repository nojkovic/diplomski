using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Configuration
{
    public class GymConfiguration : NamedEntityConfiguration<Domain.Gym>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Domain.Gym> builder)
        {
            builder.Property(x => x.Contact)
                    .IsRequired()
                    .HasMaxLength(15);

            builder.Property(x => x.WorkingTime).IsRequired().HasMaxLength(30);
            builder.Property(x => x.WorkingTimeOnWeekend).IsRequired().HasMaxLength(30);

            builder.Property(x=>x.Description).IsRequired();


            builder.HasOne(x => x.Location)
                   .WithMany(x => x.Gyms)
                   .HasForeignKey(x => x.LocationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
