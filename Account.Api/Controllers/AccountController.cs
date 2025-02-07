using Account.Domain.Models;
using Account.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Enums;
using System.Security.Claims;

namespace Account.Api.Controllers
{
    [ApiController, Authorize]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        readonly IAccountManager _accountManager;

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger, IAccountManager accountManager)
        {
            _accountManager = accountManager;
            _logger = logger;
        }

        [HttpPost("[action]"), AllowAnonymous]
        public string Authenticate(LoginModel model)
        {
            return _accountManager.Authenticate(model.Login, model.Email, model.Password);
        }

        [HttpPost("Doctor/Register")]
        public void CreateDoctorUser(LoginModel model)
        {
            _accountManager.CreateUser(model.Login, model.Email, model.Password, Roles.Doctor);
        }

        [HttpPost("Patient/Register")]
        public void CreatePatientUser(LoginModel model)
        {
            _accountManager.CreateUser(model.Login, model.Email, model.Password, Roles.Patient);
        }

        [HttpGet("[action]"), Authorize(Roles = Roles.Doctor)]
        public object Doctor()
        {
            return new
            {
                Email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value,
                Name = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value
            };
        }

        [HttpGet("[action]"), Authorize(Roles = Roles.Patient)]
        public object Patient()
        {
            return new
            {
                Email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value,
                Name = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value
            };
        }
    }
}
