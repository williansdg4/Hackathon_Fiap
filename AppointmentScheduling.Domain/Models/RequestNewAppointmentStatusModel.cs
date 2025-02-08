using System.ComponentModel.DataAnnotations;
using Shared.Domain.Enums;

namespace AppointmentScheduling.Domain.Models
{
    public class RequestNewAppointmentStatusModel
    {
        public required int Id { get; set; }
        public required AppointmentStatusEnum Status { get; set; }
        [MaxLength(30, ErrorMessage = "A justificativa de cancelamento não pode ter mais de 30 caracteres.")]
        public string? CancellationJustification { get; set; }
    }
}
