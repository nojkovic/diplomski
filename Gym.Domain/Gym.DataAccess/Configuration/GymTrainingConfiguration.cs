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
    public class GymTrainingConfiguration : EntityConfiguration<GymTraining>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<GymTraining> builder)
        {
            builder.HasOne(x => x.Training)
                  .WithMany(x => x.GymTraining)
                  .HasForeignKey(x => x.TrainingId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Gym)
                   .WithMany(x => x.GymTraining)
                   .HasForeignKey(x => x.GymId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
