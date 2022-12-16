using System.ComponentModel.DataAnnotations;

namespace API_Login.Data.Requests
{
    public class SolicitaResetRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
