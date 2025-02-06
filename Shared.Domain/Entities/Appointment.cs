using Shared.Domain.Enums;

namespace Shared.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public int IdTimeSchedule { get; set; }
        public AppointmentStatusEnum Status { get; set; }
        public string? CancellationJustification { get; set; }
    }
}
