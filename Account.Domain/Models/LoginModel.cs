using Shared.Domain.Auxiliar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Account.Domain.Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessages.UserRequired)]
        public required string User { get; set;}

        [PasswordPropertyText(true), Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessages.PasswordRequired)]
        public required string Password { get; set;}
    }
}
