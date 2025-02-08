using System.ComponentModel.DataAnnotations;
using Shared.Domain.Auxiliar;
using Shared.Domain.Enums;

namespace AppointmentScheduling.Domain.Models
{
    public class RequestNewAppointmentStatusModel
    {
        public required int Id { get; set; }
        public required AppointmentStatusEnum Status { get; set; }
        [MaxLength(30, ErrorMessage = ErrorMessages.JustificationLength)]
        public string? CancellationJustification { get; set; }
    }
}
