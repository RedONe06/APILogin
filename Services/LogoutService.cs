using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace API_Login.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result DeslogarUsuario()
        {
            var deslogar = _signInManager.SignOutAsync();
            if (deslogar.IsCompletedSuccessfully)
            {
                return Result.Ok().WithSuccess("Deslogado com sucesso");
            }
            return Result.Fail("Logout falhou.");
        }
    }
}
