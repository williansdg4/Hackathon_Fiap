using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;

namespace Shared.Infrastructure.Configurations
{
    public class TimeScheduleConfiguration : IEntityTypeConfiguration<TimeSchedule>
    {
        public void Configure(EntityTypeBuilder<TimeSchedule> builder)
        {
            builder.ToTable("TimeSchedule");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnType("INT").ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(d => d.IdDoctor).HasColumnType("INT").IsRequired();
            builder.Property(d => d.AvailableDate).HasColumnType("DATE").IsRequired();
            builder.Property(d => d.AvailableHours).HasColumnType("VARCHAR(5)").IsRequired();
        }
    }
}
