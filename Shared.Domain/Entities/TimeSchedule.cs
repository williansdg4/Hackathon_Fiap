namespace Shared.Domain.Entities
{
    public class TimeSchedule
    {
        public int Id { get; set; }
        public int IdDoctor { get; set; }
        public DateTime AvailableDate { get; set; }
        public string AvailableHours { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
