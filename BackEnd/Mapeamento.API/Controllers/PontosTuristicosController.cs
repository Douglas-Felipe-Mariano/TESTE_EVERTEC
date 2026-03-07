using Mapeamento.Application.DTOs;
using Mapeamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mapeamento.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PontosTuristicosController : ControllerBase
{
    private readonly IPontoTuristicoService _pontoTuristicoService;

    public PontosTuristicosController(IPontoTuristicoService pontoTuristicoService)
    {
        _pontoTuristicoService = pontoTuristicoService;
    }

    [HttpGet]
    public async Task<IActionResult> Listar([FromQuery] int pagina=1, [FromQuery] int tamanhoPagina=10, [FromQuery] string? busca = null)
    {
        var (itens, contaRegistros) = await _pontoTuristicoService.ListarPontosTuristicosAsync(pagina, tamanhoPagina, busca);
        return Ok(new {itens, contaRegistros, pagina, tamanhoPagina});
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var pontoTuristico = await _pontoTuristicoService.BuscarPorIdAsync(id);

        if (pontoTuristico == null)
        {
            return NotFound(new { message = "Ponto turístico não encontrado." });
        }

        return Ok(pontoTuristico);
    }

    [HttpGet("estados")]
    public async Task<IActionResult> ListarEstados()
    {
        var estados = await _pontoTuristicoService.ListarEstadosAsync();
        return Ok(estados);
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] PontoTuristicoRequestDTO request)
    {
        try
        {
            await _pontoTuristicoService.CadastrarPontoTuristicoAsync(request);
            return StatusCode(201);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] PontoTuristicoRequestDTO request)
    {
        try {
            await _pontoTuristicoService.AtualizarPontoTuristicoAsync(id, request);
            return NoContent();
        } catch (Exception ex) {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        await _pontoTuristicoService.ExcluirPontoAsync(id);
        return NoContent();
    }
}