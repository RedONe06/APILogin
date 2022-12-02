using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace API_Login.Data.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
