using System.ComponentModel.DataAnnotations;

namespace VigilyAPI.DTOs;

public class VigilanteDTO
{
    [Required]
    [StringLength(80)]
    public string Nome { get; set; }

    [Required]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter 11 dígitos numéricos")]
    public string Cpf { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Phone]
    public string Telefone { get; set; }

    [Required]
    public string Cidade { get; set; }

    [Required]
    public string Estado { get; set; }

    [Required]
    [StringLength(200)]
    public string UrlImagemPerfil { get; set; }

    [Required]
    public string Senha { get; set; }
}
