using Microsoft.EntityFrameworkCore;
using VigilyAPI.Context;
using VigilyAPI.DTOs;
using VigilyAPI.Interfaces;
using VigilyAPI.Models;

namespace VigilyAPI.Services;

public class VigilanteService : IVigilanteService
{
    private readonly VigilyAPICon _vigily;
    private readonly IPasswordHasher _passwordHasher;

    public VigilanteService(VigilyAPICon contexto, IPasswordHasher passwordHasher)
    {
        _vigily = contexto;
        _passwordHasher = passwordHasher;
    }

    public async Task<Vigilante> LoginAsync(string cpf, string senhaDigitada)
    {
        var vigilante = await _vigily.Vigilante.FirstOrDefaultAsync(x => x.Cpf == cpf);

        if (vigilante == null || !_passwordHasher.Verify(vigilante.Senha, senhaDigitada))
        {
            throw new UnauthorizedAccessException("CPF ou senha invalidos");
        }

        return vigilante;
    }

    public async Task<Vigilante> PutVigilanteAsync(string cpf, Vigilante vigilante)
    {
        var vig = await _vigily.Vigilante.FirstOrDefaultAsync(x => x.Cpf == cpf);

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
        vig.Senha = _passwordHasher.Hash(vigilante.Senha);

        _vigily.Entry(vig).State = EntityState.Modified;
        await _vigily.SaveChangesAsync();

        return vig;
    }

    public async Task<List<Vigilante>> GetVigilantesAsync()
    {
        var lista = await _vigily.Vigilante.Take(10).AsNoTracking().ToListAsync();

        if (lista == null || lista.Count() == 0)
        {
            return null;
        }
        else
        {
            return lista;
        }
    }

    public async Task<Vigilante> GetVigilanteByIDAsync(int id)
    {
        var empresa = await _vigily.Vigilante.Where(x => x.VigilanteId == id).FirstOrDefaultAsync();
        if (empresa == null)
        {
            return null;
        }
        return empresa;
    }

    public async Task<List<Vigilante>> GetVigilantePorNomeAsync(string nome)
    {
        var lista = await _vigily
            .Vigilante.Where(x => EF.Functions.Like(x.Nome, $"%{nome}%"))
            .AsNoTracking()
            .ToListAsync();

        if (lista == null || lista.Count() == 0)
        {
            return null;
        }
        else
        {
            return lista;
        }
    }

    public async Task<Vigilante> PostVigilanteAsync(VigilanteDTO vigilante, int id = 0)
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
            Senha = _passwordHasher.Hash(vigilante.Senha),
            Idade = vigilante.Idade,
        };

        _vigily.Vigilante.Add(vigilanteFinal);
        await _vigily.SaveChangesAsync();

        return vigilanteFinal;
    }
}
