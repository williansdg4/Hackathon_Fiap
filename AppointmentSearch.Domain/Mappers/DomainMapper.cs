using AppointmentSearch.Domain.Models;
using Shared.Domain.Entities;

namespace AppointmentSearch.Domain.Mappers
{
    public static class DomainMapper
    {
        public static GetAppointmentByPatient FromEntity(this Appointment entity) => new()
        {
            Id = entity.Id,
            IdDoctor = entity.IdDoctor,
            DoctorName = entity.Doctor.Name,
            DoctorSpecialty = entity.Doctor.Specialty,
            Date = entity.TimeSchedule.AvailableDate,
            Hour = entity.TimeSchedule.AvailableHours,
            Status = entity.Status.ToString(),
        };

        public static GetAppointmentByDoctorAndStatus FromEntityToDoctorAndStatus(this Appointment entity) => new()
        {
            Id = entity.Id,
            IdPatient = entity.IdPatient,
            PatientName  = entity.Patient.Name,
            Date = entity.TimeSchedule.AvailableDate,
            Hour = entity.TimeSchedule.AvailableHours,
            Status = entity.Status.ToString(),
        };
    }
}
