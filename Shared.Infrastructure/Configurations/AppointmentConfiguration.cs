using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;

namespace Shared.Infrastructure.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnType("INT").ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(d => d.IdDoctor).HasColumnType("INT").IsRequired();
            builder.Property(d => d.IdPatient).HasColumnType("INT").IsRequired();
            builder.Property(d => d.IdTimeSchedule).HasColumnType("INT").IsRequired();
            builder.Property(d => d.Status).HasColumnType("VARCHAR(50)").IsRequired();
        }
    }
}
