using AppointmentScheduling.Domain.Models;
using Shared.Domain.Auxiliar;
using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduling.Test
{
    public class UpdateAppointmentStatus
    {
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        [Fact]
        public void InsertTimeSchedule_Validate_Date_MinDate()
        {
            var errors = ValidateModel(new RequestNewAppointmentStatusModel()
            {
                Id = 0,
                CancellationJustification = "Essa é uma justificativa com mais de 30 caracteres",
                Status = Shared.Domain.Enums.AppointmentStatusEnum.Cancelled,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("CancellationJustification") && v.ErrorMessage.Contains(ErrorMessages.JustificationLength)));
        }
    }
}