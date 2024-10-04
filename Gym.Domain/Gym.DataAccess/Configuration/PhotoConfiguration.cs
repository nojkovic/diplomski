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
    public class PhotoConfiguration : EntityConfiguration<Photo>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(x => x.Path).IsRequired().HasMaxLength(60);
            builder.HasOne(x=>x.Gym)
                    .WithMany(x=>x.Photos)
                    .HasForeignKey(x=>x.GymId);
        }
    }
}
