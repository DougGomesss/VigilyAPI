using Microsoft.EntityFrameworkCore;
using VigilyAPI.Context;
using VigilyAPI.DTOs;
using VigilyAPI.Models;

namespace VigilyAPI.Services;

public class VigilanteService
{
    private readonly VigilyAPICon _vigily;

    public VigilanteService(VigilyAPICon contexto)
    {
        _vigily = contexto;
    }

    public Vigilante PutVigilante(string cpf, Vigilante vigilante)
    {
        var vig = _vigily.Vigilante.FirstOrDefault(x => x.Cpf == cpf);

        if (vig == null)
        {
            return null;
        }

        vig.Nome = vigilante.Nome;
        vig.Email = vigilante.Email;
        vig.Telefone = vigilante.Telefone;
        vig.Cidade = vigilante.Cidade;
        vig.Estado = vigilante.Estado;
        vig.UrlImagemPerfil = vigilante.UrlImagemPerfil;
        vig.Senha = vigilante.Senha;

        _vigily.Entry(vig).State = EntityState.Modified;
        _vigily.SaveChanges();

        return vig;
    }

    public List<Vigilante> GetVigilantes()
    {
        var lista = _vigily.Vigilante.Take(10).AsNoTracking().ToList();

        if (lista == null || lista.Count() == 0)
        {
            return null;
        }
        else
        {
            return lista;
        }
    }

    public Vigilante GetVigilanteByID(int id)
    {
        var empresa = _vigily.Vigilante.Where(x => x.VigilanteId == id).FirstOrDefault();
        if (empresa == null)
        {
            return null;
        }
        return empresa;
    }

    public Vigilante PostVigilante(VigilanteDTO vigilante, int id = 0)
    {
        if (vigilante == null)
        {
            return null;
        }

        var vigilanteFinal = new Vigilante
        {
            Nome = vigilante.Nome,
            Cpf = vigilante.Cpf,
            Email = vigilante.Email,
            Telefone = vigilante.Telefone,
            Cidade = vigilante.Cidade,
            Estado = vigilante.Estado,
            UrlImagemPerfil = vigilante.UrlImagemPerfil,
            Senha = vigilante.Senha,
            Idade = vigilante.Idade,
        };

        _vigily.Vigilante.Add(vigilanteFinal);
        _vigily.SaveChanges();
        return vigilanteFinal;
    }
}
