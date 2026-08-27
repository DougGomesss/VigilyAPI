using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VigilyAPI.Models;

[Table("Vigilante")]
public class Vigilante
{
    public Vigilante()
    {
        Solicitacoes = new Collection<ListaSolicitacao>();
    }

    [Key]
    public int VigilanteId { get; set; }

    [Required]
    [StringLength(80)]
    public string Nome { get; set; }

    [Required]
    [StringLength(11)]
    public string Cpf { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Senha { get; set; }

    [Required]
    public string Telefone { get; set; }

    [Required]
    public string Cidade { get; set; }

    [Required]
    public int Idade { get; set; }

    [Required]
    public string Estado { get; set; }

    [StringLength(200)]
    public string UrlImagemPerfil { get; set; }

    [StringLength(200)]
    public string RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }

    public ICollection<ListaSolicitacao> Solicitacoes { get; set; }
}
