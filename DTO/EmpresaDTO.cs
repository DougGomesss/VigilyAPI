using System.ComponentModel.DataAnnotations;

namespace VigilyAPI.DTOs;

public class EmpresaDTO
{
    [Required]
    [StringLength(80)]
    public string Nome { get; set; }

    [Required]
    [StringLength(14)]
    [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ deve conter 14 dígitos numéricos")]
    public string Cnpj { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Endereço invalido")]
    public string Email { get; set; }

    [Required]
    [Phone]
    public string Telefone { get; set; }

    [Required]
    public string Senha { get; set; }

    [Compare("Senha", ErrorMessage = "Divergencias de senha")]
    public string ConfirmarSenha { get; set; }

    [StringLength(200)]
    public string UrlImagemPerfil { get; set; }
}
