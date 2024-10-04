using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Configuration
{
    public class TrainingConfiguration : EntityConfiguration<Training>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Training> builder)
        {
            builder.Property(x => x.TrainingType)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.TrainingTypeId)
                    .IsRequired();
        }
    }
}
