using AppointmentScheduling.Domain.Models;
using AppointmentScheduling.Domain.Usecases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Enums;

namespace AppointmentScheduling.Api.Controllers
{
    /// <summary>
    /// Appointment Scheduling API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSchedulingController : ControllerBase
    {
        private readonly ILogger<AppointmentSchedulingController> _logger;
        private readonly IAppointmentSchedulingUsecase _appointmentSchedulingUsecase;

        public AppointmentSchedulingController(ILogger<AppointmentSchedulingController> logger,
            IAppointmentSchedulingUsecase appointmentSchedulingUsecase)
        {
            _logger = logger;
            _appointmentSchedulingUsecase = appointmentSchedulingUsecase;
        }

        /// <summary>
        /// Update appointment status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("[action]"), Authorize(Roles = $"{nameof(Roles.Patient)},{nameof(Roles.Doctor)}")]
        public IActionResult UpdateAppointmentStatus([FromBody] RequestNewAppointmentStatusModel model) 
        {
            if (model.Status == AppointmentStatusEnum.Cancelled && string.IsNullOrEmpty(model.CancellationJustification))
            {
                return BadRequest("A justificativa é obrigatória em caso de cancelamento");
            }

            _appointmentSchedulingUsecase.AppointmentSchedulingUpdate(model);

            return Ok();
        }

        /// <summary>
        /// Create an appointment request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]"), Authorize(Roles = Roles.Patient)]
        public IActionResult InsertAppointment([FromBody] RequestNewAppointmentModel model)
        {
            _appointmentSchedulingUsecase.AppointmentSchedulingInsert(model);

            return Ok();
        }
    }
}
