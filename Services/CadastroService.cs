using API_Login.Data.DTO;
using API_Login.Data.Requests;
using API_Login.Models;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace API_Login.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private AtivarService _ativarService;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, AtivarService ativarService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _ativarService = ativarService;
        }
        public Result CadastrarUsuario(CreateUsuarioDTO usuarioDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> criarUsuario = _userManager.CreateAsync(usuarioIdentity, usuarioDTO.Password);
            if(criarUsuario.Result.Succeeded)
            {
                string sistemaDeAtivacao = _ativarService.EnviarEmailDeConfirmacao(usuarioIdentity);
                return Result.Ok().WithSuccess(sistemaDeAtivacao);
            }
            return Result.Fail(criarUsuario.Result.ToString());
        }

        public Result AtivarUsuario(AtivaContaRequest request)
        {
            IdentityUser<int> identityUser = _userManager.Users.FirstOrDefault(usuario => usuario.Id == request.Id);

            var ativar = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;
            if(ativar.Succeeded)
            {
                return Result.Ok().WithSuccess(ativar.ToString());
            }
            return Result.Fail(ativar.ToString());
        }
    }
}
