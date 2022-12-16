using System.ComponentModel.DataAnnotations;

namespace API_Login.Data.Requests
{
    public class ExecutaResetRequest
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set;}

        [Required]
        [Compare("NewPassword")]
        public string RePassword { get; set; }
    }
}
