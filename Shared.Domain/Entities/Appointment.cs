using Shared.Domain.Enums;

namespace Shared.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }
        public int IdTimeSchedule { get; set; }
        public AppointmentStatusEnum Status { get; set; }
        public string? CancellationJustification { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual TimeSchedule TimeSchedule { get; set; }
    }
}
