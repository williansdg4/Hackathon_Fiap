using System.ComponentModel.DataAnnotations;

namespace TimeScheduleRegister.Domain.Models
{
    public class InsertTimeSchedule
    {
        public int IdDoctor { get; set; }

        [Range(typeof(DateTime), "2025-01-01", "2099-01-01", ErrorMessage = "Invalid Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
        
        [RegularExpression("([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Invalid Hour")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Hour is required")]
        public required string Hour { get; set; }
    }
}
