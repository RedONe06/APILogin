using System.ComponentModel.DataAnnotations;

namespace API_Login.Data.Requests
{
    public class AtivaContaRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string CodigoDeAtivacao { get; set; }
    }
}
