using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Gym.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;

namespace Gym.DataAccess
{
    public class GymContext:DbContext
    {
        private readonly string _connectionString;
        public GymContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public GymContext()
        {
            _connectionString = "Data Source=LAPTOP-I2PIHDS7\\MSSQLSERVER05;Initial Catalog=Gym;TrustServerCertificate=true;Integrated security = true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.IsActive = true;
                        e.CreatedAt = DateTime.UtcNow;
                    }
                }


                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<MembershipFee> MembershipFees { get; set; }
        public DbSet<GroupTraining> GroupTrainings { get; set; }
        public DbSet<PersonalTraining> PersonalTrainings { get; set;}
        public DbSet<Training> Trainings { get; set; }
        public DbSet<CoachTraining> CoachTrainings { get; set; }
        public DbSet<Domain.Gym> Gyms { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<GymTraining> GymTrainings { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<LogError> LogErrors { get; set; }
        public DbSet<UseCaseLog> UseCasesLogs { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }


    }
}

