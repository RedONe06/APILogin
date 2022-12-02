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

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
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
    }
}
