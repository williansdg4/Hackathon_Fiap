namespace DoctorSearch.Domain.Models
{
    public class GetDoctorsBySpecialty
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Specialty { get; set; }
        public IEnumerable<GetDoctorsBySpecialtySchedule>? Schedule { get; set; }
    }

    public class GetDoctorsBySpecialtySchedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Hours { get; set; }
    }
}
