using API_Login.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Login.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController: ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogarUsuario()
        {
            Result resultado = _logoutService.DeslogarUsuario();
            if(resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors.FirstOrDefault());
            }
            return Ok(resultado.Successes.FirstOrDefault());
        }
    }
}
