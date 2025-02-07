using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Account.Domain.Models
{
    public class UserModel : LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "E-mail is required")]
        [RegularExpression(@"^[a-z0-9.]+@[a-z0-9]+\.[a-z]+(\.[a-z]+)?$", ErrorMessage = "Invalid E-mail")]
        public required string Email { get; set; }
    }
}
