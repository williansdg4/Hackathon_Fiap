using System.ComponentModel.DataAnnotations;

namespace Account.Domain.Models
{
    public class InsertPatientModel : UserModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public required string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CPF is required")]
        public required string Cpf { get; set; }
    }
}
