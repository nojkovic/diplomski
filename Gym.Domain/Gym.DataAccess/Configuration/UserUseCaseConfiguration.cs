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
    public class UserUseCaseConfiguration : IEntityTypeConfiguration<UserUseCase>
    {
        public void Configure(EntityTypeBuilder<UserUseCase> builder)
        {
            builder.HasKey(x => new { x.UserId, x.UseCaseId });
        }
    }
}
