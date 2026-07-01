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
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Telefone { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string UrlImagemPerfil { get; set; }
    public ICollection<ListaSolicitacao> Solicitacoes { get; set; }
}
