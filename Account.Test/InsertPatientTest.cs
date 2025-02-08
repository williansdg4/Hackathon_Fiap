using Account.Domain.Models;
using Shared.Domain.Auxiliar;
using System.ComponentModel.DataAnnotations;

namespace Account.Test
{
    public class InsertPatientTest
    {
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        #region Cpf

        [Fact]
        public void InsertPatient_Validate_Cpf()
        {
            var errors = ValidateModel(new InsertPatientModel()
            {
                Cpf = string.Empty,
                Name = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Cpf") && v.ErrorMessage.Contains(ErrorMessages.CpfRequired)));
        }

        [Fact]
        public void InsertPatient_Validate_Cpf_LessDigits()
        {
            var errors = ValidateModel(new InsertPatientModel()
            {
                Cpf = "123",
                Name = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Cpf") && v.ErrorMessage.Contains(ErrorMessages.InvalidCpf)));
        }

        [Fact]
        public void InsertPatient_Validate_Cpf_MoreDigits()
        {
            var errors = ValidateModel(new InsertPatientModel()
            {
                Cpf = "123456789012",
                Name = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Cpf") && v.ErrorMessage.Contains(ErrorMessages.InvalidCpf)));
        }

        #endregion

        #region Email

        [Fact]
        public void InsertPatient_Validate_Email()
        {
            var errors = ValidateModel(new InsertPatientModel()
            {
                Cpf = string.Empty,
                Name = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Email") && v.ErrorMessage.Contains(ErrorMessages.EmailRequired)));
        }

        [Fact]
        public void InsertPatient_Validate_Email_NoAt()
        {
            var errors = ValidateModel(new InsertPatientModel()
            {
                Cpf = string.Empty,
                Name = string.Empty,
                Email = "mail.com",
                Password = string.Empty,
            });
            
            Assert.True(errors.Any(v => v.MemberNames.Contains("Email") && v.ErrorMessage.Contains(ErrorMessages.InvalidEmail)));
        }

        [Fact]
        public void InsertPatient_Validate_Email_NoDomain()
        {
            var errors = ValidateModel(new InsertPatientModel()
            {
                Cpf = string.Empty,
                Name = string.Empty,
                Email = "mail@.com",
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Email") && v.ErrorMessage.Contains(ErrorMessages.InvalidEmail)));
        }

        [Fact]
        public void InsertPatient_Validate_Email_NoRegion()
        {
            var errors = ValidateModel(new InsertPatientModel()
            {
                Cpf = string.Empty,
                Name = string.Empty,
                Email = "mail@mailcom",
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Email") && v.ErrorMessage.Contains(ErrorMessages.InvalidEmail)));
        }

        #endregion

        [Fact]
        public void InsertPatient_Validate_Name()
        {
            var errors = ValidateModel(new InsertPatientModel()
            {
                Cpf = string.Empty,
                Name = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Name") && v.ErrorMessage.Contains(ErrorMessages.NameRequired)));
        }

        [Fact]
        public void InsertPatient_Validate_Password()
        {
            var errors = ValidateModel(new InsertPatientModel()
            {
                Cpf = string.Empty,
                Name = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Password") && v.ErrorMessage.Contains(ErrorMessages.PasswordRequired)));
        }


    }
}