namespace Shared.Domain.Entities
{
    public class Patient: BaseEntity
    {
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
