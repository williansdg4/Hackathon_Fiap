using Account.Api.Auxiliar;
using Account.Domain.Models;
using Account.Domain.Usecases;
using Account.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Enums;

namespace Account.Api.Controllers
{
    [ApiController, ExceptionHandler, Route("[controller]"), AllowAnonymous]
    public class AccountController : ControllerBase
    {
        readonly IAccountManager _accountManager;
        readonly IDoctorRegistrationUsecase _doctorRegistrationUsecase;
        readonly IPatientRegistrationUsecase _patientRegistrationUsecase;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            IPatientRegistrationUsecase patientRegistrationUsecase,
            IDoctorRegistrationUsecase doctorRegistrationUsecase,
            IAccountManager accountManager,
            ILogger<AccountController> logger)
        {
            _patientRegistrationUsecase = patientRegistrationUsecase;
            _doctorRegistrationUsecase = doctorRegistrationUsecase;
            _accountManager = accountManager;
            _logger = logger;
        }

        /// <summary>
        /// Authenticate the user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Authenticate(LoginModel model)
        {
            return Ok(new LoginResponseModel { Token = _accountManager.Authenticate(model.User, model.Password) });
        }

        /// <summary>
        /// Register a doctor user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Doctor/Register")]
        public IActionResult CreateDoctorUser(InsertDoctorModel model)
        {
            _accountManager.CreateUser(model.Crm.ToString(), model.Email, model.Password, Roles.Doctor);
            _doctorRegistrationUsecase.Create(model);

            return Ok();
        }

        /// <summary>
        /// Register a patient user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Patient/Register")]
        public IActionResult CreatePatientUser(InsertPatientModel model)
        {
            _accountManager.CreateUser(model.Cpf, model.Email, model.Password, Roles.Patient);
            _patientRegistrationUsecase.Create(model);
            return Ok();
        }
    }
}
