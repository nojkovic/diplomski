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
    public class ReservationConfiguration : EntityConfiguration<Reservation>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasOne(x=>x.User)
                    .WithMany(x=>x.Reservations)
                    .HasForeignKey(x=>x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Gym)
                    .WithMany(x => x.Reservations)
                    .HasForeignKey(x => x.GymId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Coach)
                    .WithMany(x => x.Reservations)
                    .HasForeignKey(x => x.CoachId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Appointment)
                    .WithMany(x => x.Reservations)
                    .HasForeignKey(x => x.AppointmentId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Status)
                    .WithMany(x => x.Reservations)
                    .HasForeignKey(x => x.StatusId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
