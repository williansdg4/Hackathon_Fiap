using System.ComponentModel.DataAnnotations;

namespace Account.Domain.Models
{
    public class InsertDoctorModel : UserModel
    {
        [RegularExpression("[0-9]{6}", ErrorMessage = "Invalid CRM")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CRM is required")]
        public int Crm { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public required string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Specialty is required")]
        public required string Specialty { get; set; }
    }
}
