using TimeScheduleSearch.Domain.Models;
using Shared.Domain.Entities;

namespace TimeScheduleSearch.Domain.Mappers
{
    public static class DomainMapper
    {
        public static GetTimeSchedule FromEntity(this TimeSchedule entity) => new()
        {
            Date = entity.AvailableDate,
            Hour = entity.AvailableHours,
            DoctorName = entity.Doctor.Name,
            DoctorSpecialty = entity.Doctor.Specialty,
        };
    }
}