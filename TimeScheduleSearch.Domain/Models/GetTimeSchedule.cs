namespace TimeScheduleSearch.Domain.Models
{
    public class GetTimeSchedule
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSpecialty { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
    }}
