using Microsoft.AspNetCore.Identity;
using MimeKit;

namespace API_Login.Models
{
    public class Email
    {
        private IConfiguration _configuration;
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public Email(IEnumerable<string> destinatarios, string assunto, string mensagem)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatarios.Select(destinatario => new MailboxAddress("", destinatario)));
            Assunto = assunto;
            Conteudo = mensagem;
        }
        public void DefinirMensagemDeAtivacao(IdentityUser<int> usuarioIdentity, string codigoDeAtivacao, IConfiguration _configuration)
        {
            Conteudo = $"{_configuration.GetValue<string>("EmailSettings:UrlBase")}/ativa?Id={usuarioIdentity.Id}&CodigoDeAtivacao={codigoDeAtivacao}";
        }
    }
}
