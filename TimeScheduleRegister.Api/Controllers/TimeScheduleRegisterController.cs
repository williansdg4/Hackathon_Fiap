using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Enums;
using System.Security.Claims;
using TimeScheduleRegister.Api.Auxiliar;
using TimeScheduleRegister.Domain.Models;
using TimeScheduleRegister.Domain.Usecases;

namespace TimeScheduleRegister.Api.Controllers
{
    [ApiController, ExceptionHandler, Route("[controller]"), Authorize(Roles = Roles.Doctor)]
    public class TimeScheduleRegisterController : ControllerBase
    {
        readonly ITimeScheduleRegisterUsecase _timeScheduleRegisterUsecase;
        readonly IDoctorSearchUsecase _doctorSearchUsecase;

        private readonly ILogger<TimeScheduleRegisterController> _logger;

        public TimeScheduleRegisterController(ILogger<TimeScheduleRegisterController> logger, ITimeScheduleRegisterUsecase timeScheduleRegisterUsecase, IDoctorSearchUsecase doctorSearchUsecase)
        {
            _logger = logger;
            _timeScheduleRegisterUsecase = timeScheduleRegisterUsecase;
            _doctorSearchUsecase = doctorSearchUsecase;
        }

        /// <summary>
        /// Create a new schedule for doctor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(InsertTimeSchedule model)
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(user) || !int.TryParse(user, out var crm))
                return NoContent();

            model.IdDoctor = _doctorSearchUsecase.GetDoctorId(crm);

            _timeScheduleRegisterUsecase.Create(model);
            return Ok();
        }

        /// <summary>
        /// Update schedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(UpdateTimeSchedule model)
        {
            _timeScheduleRegisterUsecase.Update(model);
            return Ok();
        }
    }
}
