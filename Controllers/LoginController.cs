using API_Login.Data.Requests;
using API_Login.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Login.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            Result resultado = _loginService.Login(request);
            if (resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors.FirstOrDefault());
            }
            return Ok(resultado.Successes.FirstOrDefault());
        }

        [HttpPost("/solicita-reset")]
        public IActionResult SolicitarResetDeSenha(SolicitaResetRequest request)
        {
            Result resultado = _loginService.SolicitarResetDeSenha(request);
            if (resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors.FirstOrDefault());
            }
            return Ok(resultado.Successes.FirstOrDefault());
        }

        [HttpPost("/executa-reset")]
        public IActionResult ExecutarResetDeSenha(ExecutaResetRequest request)
        {
            Result resultado = _loginService.ExecutarResetDeSenha(request);
            if (resultado.IsSuccess)
            {
                return Ok(resultado.Successes.FirstOrDefault());
            }
            return BadRequest(resultado.Errors.FirstOrDefault());
        }
    }
}
