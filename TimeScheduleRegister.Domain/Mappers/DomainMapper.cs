using TimeScheduleRegister.Domain.Models;
using Shared.Domain.Entities;

namespace TimeScheduleRegister.Domain.Mappers
{
    public static class DomainMapper
    {
        public static TimeSchedule ToEntity(this InsertTimeSchedule entity) => new()
        {
            IdDoctor = entity.IdDoctor,
            AvailableDate = entity.Date,
            AvailableHours = entity.Hour.ToString()
        };
    }
}
