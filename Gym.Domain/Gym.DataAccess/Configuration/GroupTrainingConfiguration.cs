using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Configuration
{
    public class GroupTrainingConfiguration : EntityConfiguration<GroupTraining>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<GroupTraining> builder)
        {
            builder.Property(x => x.TypeOfTraining)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);

            builder.Property(x => x.PricePerTerm)
                    .IsRequired();
        }
    }
}
