using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VigilyAPI.enums;

namespace VigilyAPI.Models;

public class ListaSolicitacao
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("EmpresaId")]
    public Empresa Empresa { get; set; }

    [ForeignKey("VigilanteId")]
    public Vigilante Vigilante { get; set; }

    public EnumStatus Status { get; set; }
}
