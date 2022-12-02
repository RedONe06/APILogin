using System.ComponentModel.DataAnnotations;

namespace API_Login.Data.DTO
{
    public class CreateUsuarioDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "Deve ter no máximo 100 caracteres")]
        [MinLength(6, ErrorMessage = "Deve ter no mínimo 6 caracteres")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
