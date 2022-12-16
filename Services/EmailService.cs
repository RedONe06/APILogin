using API_Login.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Net.Mail;
using System.Net;

namespace API_Login.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Email CriarEmailDeAtivacao(string codigoAtivacao, IdentityUser<int> usuarioIdentity)
        {
            Email email = new Email(new[] { usuarioIdentity.Email }, "Link de Ativação", "");
            email.DefinirMensagemDeAtivacao(usuarioIdentity, codigoAtivacao, _configuration);
            return email;
        }

        public Email CriarEmailDeReset(string codigoReset, IdentityUser<int> usuarioIdentity)
        {
            Email email = new Email(new[] { usuarioIdentity.Email }, "Token de Reset", "");
            email.DefinirMensagemDeReset(codigoReset);
            return email;
        }

        public void EnviarEmail(Email email)
        {
            MimeMessage emailMapeado = MapearEmail(email);
            Enviar(emailMapeado);
        }

        private MimeMessage MapearEmail(Email email)
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:Username"), _configuration.GetValue<string>("EmailSettings:From")));
            mensagemDeEmail.To.AddRange(email.Destinatario);
            mensagemDeEmail.Subject = email.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = email.Conteudo };
            return mensagemDeEmail;
        }

        private void Enviar(MimeMessage email)
        {
            var porta = _configuration.GetValue<int>("EmailSettings:Port");
            var host = _configuration.GetValue<string>("EmailSettings:Host");
            var username = _configuration.GetValue<string>("EmailSettings:Username");
            var senha = _configuration.GetValue<string>("EmailSettings:Password");

            var client = new SmtpClient(host, porta)
            {
                Credentials = new NetworkCredential(username, senha),
                EnableSsl = true
            };
            client.Send("from@example.com", "to@example.com", email.Subject, email.Body.ToString());
            Console.WriteLine("Sent");
        }    
    }
}
