using Shared.Domain.Enums;

namespace AppointmentScheduling.Domain.Models
{
    public class RequestNewAppointmentModel
    {
        public required int IdDoctor { get; set; }
        public required int IdPatient { get; set; }
        public required int IdTimeSchedule { get; set; }
    }
}
