using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Account.Domain.Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "User is required")]
        public required string User { get; set;}

        [PasswordPropertyText(true), Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        public required string Password { get; set;}
    }
}
