using Microsoft.EntityFrameworkCore;
using VigilyAPI.Context;
using VigilyAPI.DTOs;
using VigilyAPI.Interfaces;
using VigilyAPI.Models;

namespace VigilyAPI.Services;

public class EmpresaService : IEmpresaService
{
    private readonly VigilyAPICon _vigily;
    private readonly IPasswordHasher _passwordHasher;

    public EmpresaService(VigilyAPICon contexto, IPasswordHasher passwordHasher)
    {
        _vigily = contexto;
        _passwordHasher = passwordHasher;
    }

    public async Task<Empresa> LoginAsync(string cnpj, string senhaDigitada)
    {
        var empresa = await _vigily.Empresa.FirstOrDefaultAsync(x => x.Cnpj == cnpj);

        if (empresa == null || !_passwordHasher.Verify(empresa.Senha, senhaDigitada))
        {
            throw new UnauthorizedAccessException("CNPJ ou senha invalidos");
        }

        return empresa;
    }

    public async Task<Empresa> AtualizarEmpresaAsync(string cnpj, Empresa empresa)
    {
        Empresa empr = await _vigily.Empresa.FirstOrDefaultAsync(x => x.Cnpj == cnpj);

        if (empr == null)
        {
            return null;
        }

        empr.Nome = empresa.Nome;
        empr.Email = empresa.Email;
        empr.Telefone = empresa.Telefone;
        empr.Senha = _passwordHasher.Hash(empresa.Senha);

        _vigily.Entry(empr).State = EntityState.Modified;
        await _vigily.SaveChangesAsync();

        return empr;
    }

    public async Task<IEnumerable<Empresa>> GetEmpresasAsync()
    {
        var lista = await _vigily.Empresa.Take(10).AsNoTracking().ToListAsync();
        if (lista == null || lista.Count() == 0)
        {
            return null;
        }

        return lista;
    }

    public async Task<Empresa> GetEmpresaPorCNPJAsync(string cnpj)
    {
        var empresa = await _vigily.Empresa.Where(x => x.Cnpj == cnpj).FirstOrDefaultAsync();
        if (empresa == null)
        {
            return null;
        }
        return empresa;
    }

    public async Task<Empresa> PostAsync(EmpresaDTO dto)
    {
        if (dto == null)
        {
            return null;
        }

        var empresa = new Empresa
        {
            Nome = dto.Nome,
            Cnpj = dto.Cnpj,
            Email = dto.Email,
            Telefone = dto.Telefone,
            Senha = _passwordHasher.Hash(dto.Senha),
        };

        _vigily.Empresa.Add(empresa);
        await _vigily.SaveChangesAsync();
        return empresa;
    }
}
