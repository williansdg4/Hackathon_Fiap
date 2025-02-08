using DoctorSearch.Domain.Models;
using Shared.Domain.Entities;

namespace DoctorSearch.Domain.Mappers
{
    public static class DomainMapper
    {
        public static GetDoctorsBySpecialty FromEntity(this Doctor entity) => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Specialty = entity.Specialty,
            Schedule = entity?.TimeSchedule?.Select(FromEntity)
        };

        public static GetDoctorsBySpecialtySchedule FromEntity(this TimeSchedule entity) => new()
        {
            Date = entity.AvailableDate,
            Hours = entity.AvailableHours
        };
    }
}
