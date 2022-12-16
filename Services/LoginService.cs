using API_Login.Data.Requests;
using API_Login.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API_Login.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;
        private ContatoService _contatoService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService, ContatoService contatoService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _contatoService = contatoService;
        }

        public Result Login(LoginRequest loginRequest)
        {
            var logar = _signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
            if (logar.Result.Succeeded)
            {
                var userIdentity = _signInManager
                    .UserManager.Users
                    .FirstOrDefault(usuario => usuario.NormalizedUserName == loginRequest.Username.ToUpper());

                Token token = _tokenService.CreateToken(userIdentity);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result SolicitarResetDeSenha(SolicitaResetRequest request)
        {
            IdentityUser<int> usuarioIdentity = EncontrarEmailNoBanco(request.Email);

            if (usuarioIdentity != null)
            {
                _contatoService.EnviarEmailDeReset(usuarioIdentity);
                return Result.Ok().WithSuccess("Um Token de reset foi enviado para o email solicitado");
            }
            return Result.Fail("Email não encontrado no banco");
        }

        public Result ExecutarResetDeSenha(ExecutaResetRequest request)
        {
            IdentityUser<int> usuarioIdentity = EncontrarEmailNoBanco(request.Email);
            Task<IdentityResult> resetar = _signInManager.UserManager.ResetPasswordAsync(usuarioIdentity, request.Token, request.NewPassword);

            if (resetar.Result.Succeeded)
            {
                return Result.Ok().WithSuccess("Resetado com sucesso. Utilize a sua nova senha no próximo acesso!");
            }
            return Result.Fail(resetar.Result.ToString());
        }

        private IdentityUser<int> EncontrarEmailNoBanco(string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(usuario => usuario.NormalizedEmail == email.ToUpper());
        }


    }
}
