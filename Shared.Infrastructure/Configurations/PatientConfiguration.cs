using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;

namespace Shared.Infrastructure.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder) 
        {
            builder.ToTable("Patient");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(p => p.Name).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(p => p.Password).HasColumnType("VARCHAR(10)").IsRequired();
            builder.HasMany(d => d.Appointment).WithOne(d => d.Patient).HasForeignKey(d => d.IdPatient).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
