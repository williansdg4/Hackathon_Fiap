using Shared.Domain.Enums;

namespace Shared.Domain.Models
{
    public class AppointmentModel
    {
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public int IdTimeSchedule { get; set; }
        public AppointmentStatusEnum Status { get; set; }
        public string? CancellationJustification { get; set; }
    }
}
