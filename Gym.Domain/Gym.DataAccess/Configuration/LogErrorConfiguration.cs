using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Gym.DataAccess.Configuration
{
    public class LogErrorConfiguration : IEntityTypeConfiguration<LogError>
    {
        public void Configure(EntityTypeBuilder<LogError> builder)
        {
            builder.Property(x => x.Message).IsRequired();
            builder.Property(x => x.StrackTrace).IsRequired();

            builder.HasKey(x => x.ErrorId);
        }
    }
}
