using API_Login.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Specialized;
using System.Web;

namespace API_Login.Services
{
    public class ContatoService
    {
        private EmailService _emailService;
        private UserManager<IdentityUser<int>> _userManager;

        public ContatoService(EmailService emailService, UserManager<IdentityUser<int>> userManager)
        {
            _emailService = emailService;
            _userManager = userManager;
        }

        public string EnviarEmailDeAtivacao(IdentityUser<int> usuarioIdentity)
        {
            string codigoAtivacao = CriarCodigoDeAtivacao(usuarioIdentity);
            Email email = _emailService.CriarEmailDeAtivacao(codigoAtivacao, usuarioIdentity);
            _emailService.EnviarEmail(email);
            return codigoAtivacao;
        }

        public string EnviarEmailDeReset(IdentityUser<int> usuarioIdentity)
        {
            string codigoReset = CriarCodigoDeReset(usuarioIdentity);
            Email email = _emailService.CriarEmailDeReset(codigoReset, usuarioIdentity);
            _emailService.EnviarEmail(email);
            return codigoReset;
        }

        private string CriarCodigoDeAtivacao(IdentityUser<int> usuarioIdentity)
        {
            var codigoAtivacao = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity);
            var urlCode = HttpUtility.UrlEncode(codigoAtivacao.Result);
            return urlCode;
        }

        private string CriarCodigoDeReset(IdentityUser<int> usuarioIdentity)
        {
            return _userManager.GeneratePasswordResetTokenAsync(usuarioIdentity).Result;
            
        }
    }
}
