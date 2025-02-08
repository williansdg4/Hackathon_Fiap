using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;

namespace Shared.Infrastructure.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctor");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnType("INT").ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(d => d.Name).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(d => d.Crm).HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(d => d.Password).HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(d => d.Specialty).HasColumnType("VARCHAR(50)").IsRequired();
            builder.HasMany(d => d.TimeSchedule).WithOne(d => d.Doctor).HasForeignKey(d => d.IdDoctor);
            builder.HasMany(d => d.Appointment).WithOne(d => d.Doctor).HasForeignKey(d => d.IdDoctor).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
