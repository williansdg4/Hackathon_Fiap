using Shared.Domain.Entities;
using Shared.Domain.Models;

namespace Shared.Domain.Mappers
{
    public static class AppointmentMapper
    {
        public static Appointment ToEntity(this InsertAppointmentModel model) => new()
        {
            IdDoctor = model.IdDoctor,
            IdPatient = model.IdPatient,
            IdTimeSchedule = model.IdTimeSchedule,
            Status = model.Status
        };

        public static Appointment ToEntity(this UpdateAppointmentModel model) => new()
        {
            Id = model.Id,
            IdDoctor = model.IdDoctor,
            IdPatient = model.IdPatient,
            IdTimeSchedule = model.IdTimeSchedule,
            Status = model.Status,
            CancellationJustification = model.CancellationJustification
        };
    }
}
