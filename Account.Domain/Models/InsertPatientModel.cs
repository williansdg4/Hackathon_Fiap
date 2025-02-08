using Shared.Domain.Auxiliar;
using System.ComponentModel.DataAnnotations;

namespace Account.Domain.Models
{
    public class InsertPatientModel : UserModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessages.NameRequired)]
        public required string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessages.CpfRequired)]
        [RegularExpression("[0-9]{11}", ErrorMessage = ErrorMessages.InvalidCpf)]
        public required string Cpf { get; set; }
    }
}
