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
    public class CoachTrainingConfiguration : EntityConfiguration<CoachTraining>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<CoachTraining> builder)
        {
            builder.HasOne(x => x.Coach)
                    .WithMany(x => x.CoachTrainings)
                    .HasForeignKey(x => x.CoachId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Training)
                   .WithMany(x => x.CoachTrainings)
                   .HasForeignKey(x => x.TrainingId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Gym)
                   .WithMany(x => x.CoachTraining)
                   .HasForeignKey(x => x.GymId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
