using DoctorSearch.Domain.Models;
using Shared.Domain.Entities;
using Shared.Domain.Enums;

namespace DoctorSearch.Domain.Mappers
{
    public static class DomainMapper
    {
        public static GetDoctorsBySpecialty FromEntity(this Doctor entity) => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Specialty = entity.Specialty,
            Schedule = entity?
                        .TimeSchedule?
                        .Where(c => !c.Appointment.Any(c => c.Status == AppointmentStatusEnum.Approved || c.Status == AppointmentStatusEnum.Pending))
                        .Select(FromEntity)
        };

        public static GetDoctorsBySpecialtySchedule FromEntity(this TimeSchedule entity) => new()
        {
            Id = entity.Id,
            Date = entity.AvailableDate,
            Hours = entity.AvailableHours
        };
    }
}
