using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using VigilyAPI.Context;
using VigilyAPI.DTOs;
using VigilyAPI.Interfaces;
using VigilyAPI.Models;
using VigilyAPI.Services;

namespace VigilyAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly VigilyAPICon _vigily;
    private readonly EmpresaService _EmpresaService;

    public EmpresaController(VigilyAPICon vigily, EmpresaService empresaService)
    {
        _vigily = vigily;
        _EmpresaService = empresaService;
    }

    [HttpGet("UsandoFromServices/{nome}")]
    public ActionResult<IEnumerable<Empresa>> GetEmpresa(IMeuService servico, string nome)
    {
        return Ok($"Esse é o meu servico : {servico.Saldacao(nome)}");
    }

    [HttpGet("GetAllPorSync")]
    public ActionResult<IEnumerable<Empresa>> GetService()
    {

        throw new Exception("Problemas na requisicao");
        var lista = _EmpresaService.GetEmpresas();
        if (lista == null || !lista.Any())
        {
            return NotFound("Nenhuma empresa encontrada");
        }
        return Ok(lista);
    }

    [HttpGet("GetAllPorAsync")]
    public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresaAsync()
    {
        return await _vigily.Empresa.AsNoTracking().ToListAsync();
    }

    Action<string> log = Console.WriteLine;

    [HttpGet("{id:int:min(1)}", Name = "ObterEmpresaPorID")]
    public ActionResult<Empresa> GetPorID(int id, [BindRequired] string nome)
    {
        Empresa empresa = _EmpresaService.GetEmpresaPorID(id);
        log(nameof(nome));
        if (empresa == null)
        {
            return NotFound("empresa não encontrada");
        }
        else
            return empresa;
    }

    [HttpGet("{values:alpha:min(14):max(14)}", Name = "GetAllWithIActionResult")]
    public IActionResult GetTeste2(string values)
    {
        Empresa emp = _vigily.Empresa.Where(x => x.Cnpj == values).FirstOrDefault();
        if (emp != null)
        {
            return Ok(values);
        }
        else
        {
            return new ObjectResult(values);
            return NotFound($"Empresa do CNPJ {emp.Cnpj} <- nao encontrado");
        }
    }

    [HttpPost]
    public ActionResult Post(EmpresaDTO empresa)
    {
        var res = _EmpresaService.Post(empresa);
        Empresa criada = _vigily.Empresa.Where(x => x.EmpresaId == res.EmpresaId).First();
        return new CreatedAtRouteResult("ObterEmpresaPorID", new { id = criada.EmpresaId }, criada);
    }

    [HttpPut("{cnpj:regex(^\\d{{14}}$)}")]
    public ActionResult Put(string cnpj, Empresa empresa)
    {
        var empresaBanco = _EmpresaService.AtualizarEmpresa(cnpj, empresa);

        if (empresaBanco == null)
        {
            return NotFound("empresa não encontrada para a atualização");
        }

        return Ok(empresaBanco);
    }

    [HttpDelete("{id:int:min(1)}")]
    public ActionResult Delete(int id)
    {
        var empresa = _vigily.Empresa.Find(id);

        if (empresa == null)
        {
            return NotFound($"empresa com o id {id} não foi encontrado");
        }
        _vigily.Empresa.Remove(empresa);
        _vigily.SaveChanges();
        return Ok($"Empresa com o id {id} excluido com sucesso");
    }
}
