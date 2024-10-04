using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Configuration
{
    public class PersonalTrainingConfiguration : EntityConfiguration<PersonalTraining>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<PersonalTraining> builder)
        {
            builder.Property(x => x.NumberOfTerms)
                   .IsRequired();

            builder.Property(x => x.Price)
                    .IsRequired();
        }
    }
}
