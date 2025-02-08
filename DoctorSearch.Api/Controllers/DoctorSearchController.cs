using DoctorSearch.Domain.Usecases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Enums;

namespace DoctorSearch.Api.Controllers
{
    /// <summary>
    /// Doctor API
    /// </summary>
    [ApiController, Route("[controller]")]
    public class DoctorSearchController : ControllerBase
    {
        private readonly ILogger<DoctorSearchController> _logger;
        readonly IDoctorSearchUsecase _doctorSearchUsecase;

        public DoctorSearchController(ILogger<DoctorSearchController> logger, IDoctorSearchUsecase doctorSearchUsecase)
        {
            _logger = logger;
            _doctorSearchUsecase = doctorSearchUsecase;
        }

        /// <summary>
        /// Get doctors by specialty
        /// </summary>
        /// <param name="specialty"></param>
        /// <returns></returns>
        [HttpGet("[action]"), Authorize(Roles = Roles.Patient)]
        public IActionResult Authenticate(string specialty)
        {
            var list = _doctorSearchUsecase.Get(specialty);
            return Ok(list);
        }
    }
}
