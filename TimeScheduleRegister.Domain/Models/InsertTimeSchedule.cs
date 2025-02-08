using Shared.Domain.Auxiliar;
using System.ComponentModel.DataAnnotations;

namespace TimeScheduleRegister.Domain.Models
{
    public class InsertTimeSchedule
    {
        public int IdDoctor { get; set; }

        [Range(typeof(DateTime), "2025-01-01", "2099-01-01", ErrorMessage = ErrorMessages.InvalidDate)]
        public DateTime Date { get; set; }
        
        [RegularExpression("([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = ErrorMessages.InvalidHour)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessages.HourRequired)]
        public required string Hour { get; set; }
    }
}
