using System.ComponentModel.DataAnnotations;

namespace VigilyAPI.DTOs;

public class EmpresaDTO
{
    [Required]
    [StringLength(80)]
    public string Nome { get; set; }

    [Required]
    [StringLength(20)]
    [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ deve conter 14 dígitos numéricos")]
    public string Cnpj { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Phone]
    public string Telefone { get; set; }

    [Required]
    public string Senha { get; set; }
}
