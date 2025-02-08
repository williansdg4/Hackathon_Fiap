namespace Shared.Domain.Entities
{
    public class Doctor: BaseEntity
    {
        public int Crm { get; set; }
        public string Specialty { get; set; }
        public virtual ICollection<TimeSchedule> TimeSchedule { get; set; }
    }
}
