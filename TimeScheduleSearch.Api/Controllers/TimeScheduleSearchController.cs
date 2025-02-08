using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Enums;
using System.Security.Claims;
using TimeScheduleSearch.Domain.Models;
using TimeScheduleSearch.Domain.Usecases;

namespace TimeScheduleSearch.Api.Controllers
{
    [ApiController, Route("[controller]"), Authorize(Roles = Roles.Doctor)]
    public class TimeScheduleSearchController : ControllerBase
    {
        readonly ITimeScheduleSearchUsecase _timeScheduleSearchUsecase;

        private readonly ILogger<TimeScheduleSearchController> _logger;

        public TimeScheduleSearchController(ILogger<TimeScheduleSearchController> logger, ITimeScheduleSearchUsecase timeScheduleSearchUsecase)
        {
            _logger = logger;
            _timeScheduleSearchUsecase = timeScheduleSearchUsecase;
        }

        /// <summary>
        /// Create a new schedule for doctor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(user) || !int.TryParse(user, out var crm))
                return NoContent();

            var list = _timeScheduleSearchUsecase.Get(crm).ToList();

            return Ok(list);
        }
    }
}
