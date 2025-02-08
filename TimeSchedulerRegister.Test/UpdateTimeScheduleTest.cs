using System.ComponentModel.DataAnnotations;
using TimeScheduleRegister.Domain.Models;

namespace TimeSchedulerRegister.Test
{
    public class UpdateTimeScheduleTest
    {
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }

        [Fact]
        public void UpdateTimeSchedule_Validate_Date_MinDate()
        {
            var errors = ValidateModel(new UpdateTimeSchedule()
            {
                Date = DateTime.MinValue,
                Hour = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Date") && v.ErrorMessage.Contains("Invalid Date")));
        }

        public void UpdateTimeSchedule_Validate_Date_MaxDate()
        {
            var errors = ValidateModel(new UpdateTimeSchedule()
            {
                Date = DateTime.MaxValue,
                Hour = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Date") && v.ErrorMessage.Contains("Invalid Date")));
        }

        [Fact]
        public void UpdateTimeSchedule_Validate_Hour()
        {
            var errors = ValidateModel(new UpdateTimeSchedule()
            {
                Date = DateTime.MinValue,
                Hour = string.Empty,
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Hour") && v.ErrorMessage.Contains("Hour is required")));
        }

        [Fact]
        public void UpdateTimeSchedule_Validate_Hour_InvalidFormat()
        {
            var errors = ValidateModel(new UpdateTimeSchedule()
            {
                Date = DateTime.MinValue,
                Hour = "1430",
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Hour") && v.ErrorMessage.Contains("Invalid Hour")));
        }

        [Fact]
        public void UpdateTimeSchedule_Validate_Hour_InvalidHour()
        {
            var errors = ValidateModel(new UpdateTimeSchedule()
            {
                Date = DateTime.MinValue,
                Hour = "26:30",
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Hour") && v.ErrorMessage.Contains("Invalid Hour")));
        }

        [Fact]
        public void UpdateTimeSchedule_Validate_Hour_InvalidMinutes()
        {
            var errors = ValidateModel(new UpdateTimeSchedule()
            {
                Date = DateTime.MinValue,
                Hour = "14:99",
            });

            Assert.True(errors.Any(v => v.MemberNames.Contains("Hour") && v.ErrorMessage.Contains("Invalid Hour")));
        }
    }
}