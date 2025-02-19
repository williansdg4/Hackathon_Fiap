using Account.Domain.Models;
using Shared.Domain.Auxiliar;
using System.ComponentModel.DataAnnotations;

namespace Account.Test
{
    public class InsertDoctorTest
    {
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        #region CRM

        [Fact]
        public void InsertDoctor_Validate_Crm_LessDigits()
        {
            var errors = ValidateModel(new InsertDoctorModel()
            {
                Crm = 0,
                Name = string.Empty,
                Specialty = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Crm") && v.ErrorMessage.Contains(ErrorMessages.InvalidCrm)));
        }

        [Fact]
        public void InsertDoctor_Validate_Crm_MoreDigits()
        {
            var errors = ValidateModel(new InsertDoctorModel()
            {
                Crm = 1234567,
                Name = string.Empty,
                Specialty = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Crm") && v.ErrorMessage.Contains(ErrorMessages.InvalidCrm)));
        }

        #endregion

        #region Email

        [Fact]
        public void InsertDoctor_Validate_Email()
        {
            var errors = ValidateModel(new InsertDoctorModel()
            {
                Crm = 0,
                Name = string.Empty,
                Specialty = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
            });
            
            Assert.True(errors.Any(v => v.MemberNames.Contains("Email") && v.ErrorMessage.Contains(ErrorMessages.EmailRequired)));
        }

        [Fact]
        public void InsertDoctor_Validate_Email_NoAt()
        {
            var errors = ValidateModel(new InsertDoctorModel()
            {
                Crm = 0,
                Name = string.Empty,
                Specialty = string.Empty,
                Email = "mail.com",
                Password = string.Empty,
            });
            
            Assert.True(errors.Any(v => v.MemberNames.Contains("Email") && v.ErrorMessage.Contains(ErrorMessages.InvalidEmail)));
        }

        [Fact]
        public void InsertDoctor_Validate_Email_NoDomain()
        {
            var errors = ValidateModel(new InsertDoctorModel()
            {
                Crm = 0,
                Name = string.Empty,
                Specialty = string.Empty,
                Email = "mail@.com",
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Email") && v.ErrorMessage.Contains(ErrorMessages.InvalidEmail)));
        }

        [Fact]
        public void InsertDoctor_Validate_Email_NoRegion()
        {
            var errors = ValidateModel(new InsertDoctorModel()
            {
                Crm = 0,
                Name = string.Empty,
                Specialty = string.Empty,
                Email = "mail@mailcom",
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Email") && v.ErrorMessage.Contains(ErrorMessages.InvalidEmail)));
        }

        #endregion

        [Fact]
        public void InsertDoctor_Validate_Specialty()
        {
            var errors = ValidateModel(new InsertDoctorModel()
            {
                Crm = 0,
                Name = string.Empty,
                Specialty = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
            });
            
            Assert.True(errors.Any(v => v.MemberNames.Contains("Specialty") && v.ErrorMessage.Contains(ErrorMessages.SpecialtyRequired)));
        }

        [Fact]
        public void InsertDoctor_Validate_Name()
        {
            var errors = ValidateModel(new InsertDoctorModel()
            {
                Crm = 0,
                Name = string.Empty,
                Specialty = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Name") && v.ErrorMessage.Contains(ErrorMessages.NameRequired)));
        }

        [Fact]
        public void InsertDoctor_Validate_Password()
        {
            var errors = ValidateModel(new InsertDoctorModel()
            {
                Crm = 0,
                Name = string.Empty,
                Specialty = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Password") && v.ErrorMessage.Contains(ErrorMessages.PasswordRequired)));
        }


    }
}