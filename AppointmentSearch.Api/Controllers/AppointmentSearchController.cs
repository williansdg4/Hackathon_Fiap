using AppointmentSearch.Domain.Usecases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Enums;
using System.Security.Claims;

namespace AppointmentSearch.Api.Controllers
{
    /// <summary>
    /// Search appointments
    /// </summary>
    [ApiController, Route("[controller]")]
    public class AppointmentSearchController : ControllerBase
    {
        private readonly ILogger<AppointmentSearchController> _logger;
        readonly IAppointmentSearchUsecase _appointmentSearchUsecase;

        public AppointmentSearchController(ILogger<AppointmentSearchController> logger, IAppointmentSearchUsecase appointmentSearchUsecase)
        {
            _logger = logger;
            _appointmentSearchUsecase = appointmentSearchUsecase;
        }

        /// <summary>
        /// Get all appointments of current user (patient)
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]"), Authorize(Roles = Roles.Patient)]
        public IActionResult GetMyAppointments()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(user))
            {
                return NoContent();
            }

            var list = _appointmentSearchUsecase.GetByPatient(user).ToList();

            return Ok(list);
        }

        /// <summary>
        /// Get pending appointments of current user (doctor)
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]"), Authorize(Roles = Roles.Doctor)]
        public IActionResult GetPendingAppointments()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(user) || !int.TryParse(user, out var crm))
                return NoContent();

            var list = _appointmentSearchUsecase.GetPendingByDoctor(crm).ToList();

            return Ok(list);
        }
    }
}
