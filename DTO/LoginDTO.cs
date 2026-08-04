using System.ComponentModel.DataAnnotations;

namespace VigilyAPI.DTO
{
    public class LoginDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
