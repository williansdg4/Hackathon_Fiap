using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSearch.Domain.Models
{
    public class GetAppointmentByDoctorAndStatus
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public required string PatientName { get; set; }
        public DateTime Date { get; set; }
        public required string Hour { get; set; }
        public required string Status { get; set; }
    }
}
