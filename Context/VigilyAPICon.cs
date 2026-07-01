using Microsoft.EntityFrameworkCore;
using VigilyAPI.Models;

namespace VigilyAPI.Context;

public class VigilyAPICon : DbContext
{
    public VigilyAPICon(DbContextOptions<VigilyAPICon> contexto)
        : base(options: contexto) { }

    public DbSet<Vigilante> Vigilante { get; set; }
    public DbSet<Empresa> Empresa { get; set; }
    public DbSet<ListaSolicitacao> ListaSolicitacoes { get; set; }
}
