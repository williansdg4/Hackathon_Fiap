using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TimeScheduleRegister.Domain.Models
{
    public class UpdateTimeSchedule
    {
        public int Id { get; set; }

        [Range(typeof(DateTime), "2025-01-01", "2099-01-01", ErrorMessage = "Invalid Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [RegularExpression("([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Invalid Hour")]
        public required string Hour { get; set; }
    }
}
