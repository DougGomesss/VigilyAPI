using System.ComponentModel.DataAnnotations;

namespace VigilyAPI.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Senha { get; set; }
    }
}
