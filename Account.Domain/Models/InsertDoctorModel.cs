using Shared.Domain.Auxiliar;
using System.ComponentModel.DataAnnotations;

namespace Account.Domain.Models
{
    public class InsertDoctorModel : UserModel
    {
        [RegularExpression("[0-9]{6}", ErrorMessage = ErrorMessages.InvalidCrm)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessages.CrmRequired)]
        public int Crm { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessages.NameRequired)]
        public required string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessages.SpecialtyRequired)]
        public required string Specialty { get; set; }
    }
}
