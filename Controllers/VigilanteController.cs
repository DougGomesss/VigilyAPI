using Microsoft.AspNetCore.Mvc;
using VigilyAPI.Context;
using VigilyAPI.DTO;
using VigilyAPI.DTOs;
using VigilyAPI.Interfaces;
using VigilyAPI.Models;
using VigilyAPI.Services;

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
    public ActionResult<IEnumerable<Vigilante>> GetVigilantes(IVigilanteService vigilanteService)
    {
        var lista = vigilanteService.GetVigilantes();
        if (lista == null || lista.Count() == 0)
        {
            return BadRequest();
        }
        else
        {
            return lista;
        }
    }


    [HttpPost("Login")]
    public async Task<ActionResult> LoginVigilante(IVigilanteService vigilanteService,LoginDTO login)
    {
        Vigilante vigilante = await vigilanteService.Login(login.Login, login.Senha);
        return Ok(
            new
            {
                vigilante.VigilanteId,
                vigilante.Nome,
                vigilante.Cpf,
                vigilante.Email,
            }
        );
    }

    [HttpGet("{id:int:min(1)}", Name = "ObterVigilantePorID")]
    public ActionResult<Vigilante> GetPorID(IVigilanteService vigilanteService,int id)
    {
        Vigilante vigilante = vigilanteService.GetVigilanteByID(id);
        if (vigilante == null)
        {
            return NotFound("vigilante não encontrado");
        }
        else
            return vigilante;
    }

    [HttpPost]
    public ActionResult Post(IVigilanteService vigilanteService,VigilanteDTO vigilante)
    {
        var res = vigilanteService.PostVigilante(vigilante);
        Vigilante teste = _vigily.Vigilante.Where(x => x.VigilanteId == res.VigilanteId).First();
        return new CreatedAtRouteResult(
            "ObterVigilantePorID",
            new { id = teste.VigilanteId },
            teste
        );
    }

    [HttpPut("{cpf:regex(^\\d{{11}}$)}")]
    public ActionResult Put(IVigilanteService vigilanteService,string cpf, Vigilante vigilante)
    {
        var vigilanteBanco = vigilanteService.PutVigilante(cpf, vigilante);

        if (vigilanteBanco == null)
        {
            return NotFound("vigilante não encontrado");
        }

        return Ok(vigilanteBanco);
    }

    [HttpDelete("{id:int:min(1)}")]
    public ActionResult Delete(int id)
    {
        var vigilante = _vigily.Vigilante.Where(x => x.VigilanteId == id).FirstOrDefault();
        if (vigilante == null)
        {
            return NotFound($"vigilante com o id {id} não foi encontrado");
        }
        _vigily.Vigilante.Remove(vigilante);
        _vigily.SaveChanges();
        return Ok($"Vigilante com o id {id} excluido com sucesso");
    }
}
