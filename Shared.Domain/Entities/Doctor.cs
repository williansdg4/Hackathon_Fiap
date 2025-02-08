namespace Shared.Domain.Entities
{
    public class Doctor: BaseEntity
    {
        public int Crm { get; set; }
        public string Specialty { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<TimeSchedule> TimeSchedule { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
