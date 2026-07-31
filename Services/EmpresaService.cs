using Microsoft.EntityFrameworkCore;
using VigilyAPI.Context;
using VigilyAPI.DTOs;
using VigilyAPI.Models;

namespace VigilyAPI.Services;

public class EmpresaService
{
    private readonly VigilyAPICon _vigily;

    public EmpresaService(VigilyAPICon contexto)
    {
        _vigily = contexto;
    }

    public Empresa AtualizarEmpresa(string cnpj, Empresa empresa)
    {
        Empresa empr = _vigily.Empresa.FirstOrDefault(x => x.Cnpj == cnpj);

        if (empr == null)
        {
            return null;
        }

        empr.Nome = empresa.Nome;
        empr.Email = empresa.Email;
        empr.Telefone = empresa.Telefone;
        empr.Senha = empresa.Senha;

        _vigily.Entry(empr).State = EntityState.Modified;
        _vigily.SaveChanges();

        return empr;
    }

    public IEnumerable<Empresa> GetEmpresas()
    {
        var lista = _vigily.Empresa.Take(10).AsNoTracking().ToList();
        if (lista == null || lista.Count() == 0)
        {
            return null;
        }
        else
        {
            return lista;
        }
    }

    public Empresa GetEmpresaPorID(int id)
    {
        var empresa = _vigily.Empresa.Where(x => x.EmpresaId == id).FirstOrDefault();
        if (empresa == null)
        {
            return null;
        }
        return empresa;
    }

    public Empresa Post(EmpresaDTO dto)
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
            Senha = dto.Senha,
        };

        _vigily.Empresa.Add(empresa);
        _vigily.SaveChanges();
        return empresa;
    }
}
