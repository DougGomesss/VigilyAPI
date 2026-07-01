using Microsoft.AspNetCore.Mvc;
using VigilyAPI.Context;
using VigilyAPI.DTOs;
using VigilyAPI.Models;
using VigilyAPI.Services;

namespace VigilyAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class VigilanteController : ControllerBase
{
    private readonly VigilyAPICon _vigily;
    private readonly VigilanteService _VigilanteService;

    public VigilanteController(VigilyAPICon vigily, VigilanteService vigilanteService)
    {
        _vigily = vigily;
        _VigilanteService = vigilanteService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Vigilante>> GetVigilantes()
    {
        var lista = _VigilanteService.GetVigilantes();
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
    public ActionResult<Vigilante> GetPorID(int id)
    {
        Vigilante vigilante = _VigilanteService.GetVigilanteByID(id);
        if (vigilante == null)
        {
            return NotFound("vigilante não encontrado");
        }
        else
            return vigilante;
    }


    [HttpPost]
    public ActionResult Post(VigilanteDTO vigilante)
    {
        var res = _VigilanteService.PostVigilante(vigilante);
        Vigilante teste = _vigily.Vigilante.Where(x => x.VigilanteId == res.VigilanteId).First();
        return new CreatedAtRouteResult(
            "ObterVigilantePorID",
            new { id = teste.VigilanteId },
            teste
        ); // <- retona 201
    }

    [HttpPut("{cpf:regex(^\\d{{11}}$)}")]
    public ActionResult Put(string cpf, Vigilante vigilante)
    {
        var vigilanteBanco = _VigilanteService.PutVigilante(cpf, vigilante);

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
