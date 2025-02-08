using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.Domain.Entities;

namespace Shared.Infrastructure.DBContext
{
    public class ApplicationDbContextConsumer : DbContext
    {
        private readonly string? _connString;

        public DbSet<Patient> Patients {  get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<TimeSchedule> TimeSchedules { get; set; }

        public ApplicationDbContextConsumer() { }

        public ApplicationDbContextConsumer(DbContextOptions<ApplicationDbContextConsumer> options) : base(options)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            _connString = configuration.GetConnectionString("HealthMedScheduling")
                ?? throw new Exception("String de conexão não informada");
        }

        public ApplicationDbContextConsumer(string connString) { _connString = connString; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContextConsumer).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
