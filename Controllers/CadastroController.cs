using API_Login.Data.DTO;
using API_Login.Data.Requests;
using API_Login.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Login.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService= cadastroService;
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(CreateUsuarioDTO usuarioDTO)
        {
            Result resultado = _cadastroService.CadastrarUsuario(usuarioDTO);
            if (resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors.FirstOrDefault());
            }
            return Ok(resultado.Successes.FirstOrDefault());
        }

        [HttpGet("/ativa")]
        public IActionResult AtivarUsuario([FromQuery] AtivaContaRequest request)
        {
            Result resultado = _cadastroService.AtivarUsuario(request);
            if (resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors.FirstOrDefault());
            }
            return Ok(resultado.Successes.FirstOrDefault());

        }
    }
}
