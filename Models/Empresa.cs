using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VigilyAPI.Models;

[Table("Empresa")]
public class Empresa
{
    public Empresa()
    {
        Solicitacoes = new Collection<ListaSolicitacao>();
    }

    [Key]
    public int EmpresaId { get; set; }

    [Required]
    [StringLength(80)]
    public string Nome { get; set; }

    [Required]
    [StringLength(14)]
    public string Cnpj { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Telefone { get; set; }

    [Required]
    public string Senha { get; set; }

    [StringLength(200)]
    public string UrlImagemPerfil { get; set; }

    [StringLength(200)]
    public string RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }

    public ICollection<ListaSolicitacao> Solicitacoes { get; set; }
}
