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
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);

            builder.Property(x => x.Subject)
                    .IsRequired()
                    .HasMaxLength(20);

            builder.Property(x => x.Message).IsRequired().HasMaxLength(150);
        }

        
    }
}
