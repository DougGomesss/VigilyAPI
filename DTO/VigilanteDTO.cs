using System.ComponentModel.DataAnnotations;
using VigilyAPI.Validations;

namespace VigilyAPI.DTOs;

public class VigilanteDTO
{
    [Required]
    [StringLength(80)]
    [PrimeiraLetraMaiuscula]
    public string Nome { get; set; }

    [Required]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter 11 dígitos numéricos")]
    public string Cpf { get; set; }

    [Required]
    [Range(21, 70, ErrorMessage = "A idade precisa estar entre 21 e 70")]
    public int Idade { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Endereço Invalido")]
    public string Email { get; set; }

    [Required]
    [Phone]
    public string Telefone { get; set; }

    [Required]
    public string Cidade { get; set; }

    [Required]
    public string Estado { get; set; }

    [StringLength(200)]
    public string UrlImagemPerfil { get; set; }

    [Required]
    public string Senha { get; set; }

    [Compare("Senha", ErrorMessage = "Divergencias de senha")]
    public string ConfirmarSenha { get; set; }
}
