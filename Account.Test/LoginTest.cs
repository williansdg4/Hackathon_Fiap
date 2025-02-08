using Account.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Account.Test
{
    public class LoginTest
    {
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        [Fact]
        public void Login_Validate_User()
        {
            var errors = ValidateModel(new LoginModel()
            {
                User = string.Empty,
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("User") && v.ErrorMessage.Contains("User is required")));
        }

        [Fact]
        public void Login_Validate_Password()
        {
            var errors = ValidateModel(new LoginModel()
            {
                User = string.Empty,
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Password") && v.ErrorMessage.Contains("Password is required")));
        }
    }
}