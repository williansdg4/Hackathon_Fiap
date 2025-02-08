using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Shared.Domain.Auxiliar;

namespace Account.Domain.Models
{
    public class UserModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessages.EmailRequired)]
        [RegularExpression(@"^[a-z0-9.]+@[a-z0-9]+\.[a-z]+(\.[a-z]+)?$", ErrorMessage = ErrorMessages.InvalidEmail)]
        public required string Email { get; set; }

        [PasswordPropertyText(true), Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessages.PasswordRequired)]
        public required string Password { get; set; }
    }
}
