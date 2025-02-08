using System.ComponentModel.DataAnnotations;

namespace TimeScheduleRegister.Domain.Models
{
    public class InsertTimeSchedule
    {
        public int IdDoctor { get; set; }
        
        public DateTime Date { get; set; }
        
        [RegularExpression("([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Invalid Hour")]
        public required string Hour { get; set; }
    }}
