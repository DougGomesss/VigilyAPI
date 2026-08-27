using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VigilyAPI.Context;
using VigilyAPI.DTOs;
using VigilyAPI.Interfaces;
using VigilyAPI.Models;

namespace VigilyAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class VigilanteController : ControllerBase
{
    private readonly VigilyAPICon _vigily;

    public VigilanteController(VigilyAPICon vigily)
    {
        _vigily = vigily;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vigilante>>> GetVigilantesAsync(IVigilanteService vigilanteService)
    {
        var lista = await vigilanteService.GetVigilantesAsync();
        if (lista == null || lista.Count() == 0)
        {
            return BadRequest();
        }
        else
        {
            return lista;
        }
    }

    [HttpGet("{id:int:min(1)}", Name = "ObterVigilantePorID")]
    public async Task<ActionResult<Vigilante>> GetPorIDAsync(IVigilanteService vigilanteService, int id)
    {
        Vigilante vigilante = await vigilanteService.GetVigilanteByIDAsync(id);
        if (vigilante == null)
        {
            return NotFound("vigilante não encontrado");
        }
        else
            return vigilante;
    }

    [HttpGet("busca", Name = "ObterVigilantePorNome")]
    public async Task<ActionResult<IEnumerable<Vigilante>>> GetPorNomeAsync(IVigilanteService vigilanteService, [FromQuery] string nome)
    {
        var lista = await vigilanteService.GetVigilantePorNomeAsync(nome);
        if (lista == null || !lista.Any())
        {
            return NotFound("nenhum vigilante encontrado com esse nome");
        }
        return Ok(lista);
    }

    [HttpPost]
    public async Task<ActionResult> PostVigilanteAsync(IVigilanteService vigilanteService, VigilanteDTO vigilante)
    {
        var res = await vigilanteService.PostVigilanteAsync(vigilante);
        Vigilante teste = await _vigily.Vigilante.Where(x => x.VigilanteId == res.VigilanteId).FirstAsync();
        return new CreatedAtRouteResult(
            "ObterVigilantePorNome",
            new { nome = teste.Nome },
            teste
        );
    }

    [HttpPut("{cpf:regex(^\\d{{11}}$)}")]
    public async Task<ActionResult> PutVigilanteAsync(IVigilanteService vigilanteService, string cpf, Vigilante vigilante)
    {
        var vigilanteBanco = await vigilanteService.PutVigilanteAsync(cpf, vigilante);

        if (vigilanteBanco == null)
        {
            return NotFound("vigilante não encontrado");
        }

        return Ok(vigilanteBanco);
    }

    [HttpDelete("{id:int:min(1)}")]
    public async Task<ActionResult> DeleteVigilanteAsync(int id)
    {
        var vigilante = await _vigily.Vigilante.Where(x => x.VigilanteId == id).FirstOrDefaultAsync();
        if (vigilante == null)
        {
            return NotFound($"vigilante com o id {id} não foi encontrado");
        }

        var possuiSolicitacoes = await _vigily.ListaSolicitacoes.AnyAsync(x => x.Vigilante.VigilanteId == id);
        if (possuiSolicitacoes)
        {
            return Conflict($"não é possível excluir: existem solicitações vinculadas ao vigilante com o id {id}");
        }

        _vigily.Vigilante.Remove(vigilante);
        await _vigily.SaveChangesAsync();
        return Ok($"Vigilante com o id {id} excluido com sucesso");
    }
}
