using AppointmentScheduling.Domain.Models;
using Shared.Domain.Entities;
using Shared.Domain.Models;

namespace AppointmentScheduling.Domain.Mappers
{
    public static class AppointmentSchedulingMapper
    {
        public static Appointment RequestInsertToEntity(this RequestNewAppointmentModel model) => new()
        {
            IdDoctor = model.IdDoctor,
            IdPatient = model.IdPatient,
            IdTimeSchedule = model.IdTimeSchedule
        };

        public static Appointment RequestUpdateToEntity(this RequestNewAppointmentStatusModel model) => new()
        {
            Id = model.Id,
            Status = model.Status,
            CancellationJustification = model.CancellationJustification
        };
    }
}
