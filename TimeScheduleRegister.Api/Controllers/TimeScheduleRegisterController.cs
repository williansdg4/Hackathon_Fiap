using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Enums;
using TimeScheduleRegister.Api.Auxiliar;
using TimeScheduleRegister.Domain.Models;
using TimeScheduleRegister.Domain.Usecases;

namespace TimeScheduleRegister.Api.Controllers
{
    [ApiController, ExceptionHandler, Route("[controller]"), Authorize(Roles = Roles.Doctor)]
    public class TimeScheduleRegisterController : ControllerBase
    {
        readonly ITimeScheduleRegisterUsecase _timeScheduleRegisterUsecase;

        private readonly ILogger<TimeScheduleRegisterController> _logger;

        public TimeScheduleRegisterController(ILogger<TimeScheduleRegisterController> logger, ITimeScheduleRegisterUsecase timeScheduleRegisterUsecase)
        {
            _logger = logger;
            _timeScheduleRegisterUsecase = timeScheduleRegisterUsecase;
        }

        /// <summary>
        /// Create a new schedule for doctor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(InsertTimeSchedule model)
        {
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
