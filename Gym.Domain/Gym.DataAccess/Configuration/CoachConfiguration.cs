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
    public class CoachConfiguration : EntityConfiguration<Coach>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Coach> builder)
        {
            builder.Property(x => x.Description)
                     .IsRequired()
                     .HasMaxLength(150);
            builder.Property(x => x.Name)
                  .IsRequired()
                  .HasMaxLength(40);

            builder.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasOne(x=>x.Gym)
                    .WithMany(x=>x.Coaches)
                    .HasForeignKey(x=>x.GymId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Photo).IsRequired();
        }
    }
}
