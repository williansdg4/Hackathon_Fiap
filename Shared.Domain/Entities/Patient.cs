namespace Shared.Domain.Entities
{
    public class Patient: BaseEntity
    {
        public string Cpf { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
