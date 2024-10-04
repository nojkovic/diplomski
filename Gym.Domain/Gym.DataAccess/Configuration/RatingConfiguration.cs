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
    public class RatingConfiguration : EntityConfiguration<Rating>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Rating> builder)
        {
            builder.Property(x => x.Rate)
                   .IsRequired()
                   .HasColumnType("tinyint");

            builder.HasOne(x => x.Gym)
                   .WithMany(x => x.Ratings)
                   .HasForeignKey(x => x.GymId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Ratings)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
