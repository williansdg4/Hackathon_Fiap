using System.ComponentModel.DataAnnotations;

namespace Account.Domain.Models
{
    public class InsertPatientModel : UserModel
    {
        [RegularExpression("[0-9]{6}", ErrorMessage = "Invalid CRM")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public required string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CPF is required")]
        [RegularExpression("[0-9]{11}", ErrorMessage = "Invalid CPF")]
        public required string Cpf { get; set; }
    }
}
