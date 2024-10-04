using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Configuration
{
    public class MembershipFeeConfiguration : EntityConfiguration<MembershipFee>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<MembershipFee> builder)
        {
            builder.Property(x => x.TypeOfMembership)
                     .IsRequired()
                     .HasMaxLength(50);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
           
            builder.Property(x => x.Price)
                    .IsRequired();
        }
    }
}
