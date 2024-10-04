using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Configuration
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name)
                  .IsRequired()
                  .HasMaxLength(40);

            builder.Property(x => x.Contact)
                    .IsRequired()
                    .HasMaxLength(15);

            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.Password).IsRequired();
        }
    }
}
