using System.ComponentModel.DataAnnotations;

namespace Account.Domain.Models
{
    public class InsertDoctorModel : UserModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Crm is required")]
        public int Crm { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "User is required")]
        public required string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Specialty is required")]
        public required string Specialty { get; set; }
    }
}
