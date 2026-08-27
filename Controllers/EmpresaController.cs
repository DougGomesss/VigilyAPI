using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VigilyAPI.Context;
using VigilyAPI.DTOs;
using VigilyAPI.Filters;
using VigilyAPI.Interfaces;
using VigilyAPI.Models;
using VigilyAPI.Services;

namespace VigilyAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly VigilyAPICon _vigily;

    public EmpresaController(VigilyAPICon vigily)
    {
        _vigily = vigily;
    }

    [HttpGet("ListaEmpresas")]
    [ServiceFilter(typeof(ApiLogginFilter))]
    [Authorize(Roles = "Vigilante")]
    public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresaAsync(IEmpresaService empresaService)
    {
        IEnumerable<Empresa> listaEmpresa = await empresaService.GetEmpresasAsync();

        if (listaEmpresa == null || !listaEmpresa.Any())
        {
            return NotFound("Nenhuma empresa encontrada");
        }
        return Ok(listaEmpresa);
    }

    [HttpGet("{cnpj:regex(^\\d{{14}}$)}", Name = "ObterEmpresaPorCNPJ")]
    public async Task<ActionResult<Empresa>> GetPorCNPJAsync(IEmpresaService empresaService, string cnpj)
    {
        Empresa empresa = await empresaService.GetEmpresaPorCNPJAsync(cnpj);
        if (empresa == null)
        {
            return NotFound("empresa não encontrada");
        }
        else
            return empresa;
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync(IEmpresaService empresaService, EmpresaDTO empresa)
    {
        var res = await empresaService.PostAsync(empresa);
        Empresa criada = await _vigily.Empresa.Where(x => x.EmpresaId == res.EmpresaId).FirstAsync();
        return new CreatedAtRouteResult("ObterEmpresaPorCNPJ", new { cnpj = criada.Cnpj }, criada);
    }

    [HttpPut("{cnpj:regex(^\\d{{14}}$)}")]
    public async Task<ActionResult> PutAsync(IEmpresaService empresaService, string cnpj, Empresa empresa)
    {
        var empresaBanco = await empresaService.AtualizarEmpresaAsync(cnpj, empresa);

        if (empresaBanco == null)
        {
            return NotFound("empresa não encontrada para a atualização");
        }

        return Ok(empresaBanco);
    }

    [HttpDelete("{id:int:min(1)}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var empresa = await _vigily.Empresa.FindAsync(id);

        if (empresa == null)
        {
            return NotFound($"empresa com o id {id} não foi encontrado");
        }

        var possuiSolicitacoes = await _vigily.ListaSolicitacoes.AnyAsync(x => x.Empresa.EmpresaId == id);
        if (possuiSolicitacoes)
        {
            return Conflict($"não é possível excluir: existem solicitações vinculadas à empresa com o id {id}");
        }

        _vigily.Empresa.Remove(empresa);
        await _vigily.SaveChangesAsync();
        return Ok($"Empresa com o id {id} excluido com sucesso");
    }
}
