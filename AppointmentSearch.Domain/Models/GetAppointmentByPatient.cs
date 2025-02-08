using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSearch.Domain.Models
{
    public class GetAppointmentByPatient
    {
        public int Id { get; set; }
        public int IdDoctor { get; set; }
        public required string DoctorName { get; set; }
        public required string DoctorSpecialty { get; set; }
        public DateTime Date { get; set; }
        public required string Hour { get; set; }
        public required string Status { get; set; }
    }
}
