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
    public class AppointmentConfiguration : EntityConfiguration<Appointment>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Appointment> builder)
        {
           builder.HasOne(x=>x.CoachTraining)
                    .WithMany(x=>x.Appointments)
                    .HasForeignKey(x=>x.CoachTrainingId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Gym)
                   .WithMany(x => x.Appointments)
                   .HasForeignKey(x => x.GymId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Date).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Time).IsRequired().HasMaxLength(30);

        }
    }
}
