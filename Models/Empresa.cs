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
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Telefone { get; set; }
    public ICollection<ListaSolicitacao> Solicitacoes { get; set; }
}
