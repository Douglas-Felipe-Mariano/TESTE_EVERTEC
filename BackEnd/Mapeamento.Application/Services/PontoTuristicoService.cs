using Mapeamento.Application.DTOs;
using Mapeamento.Domain.Entities;
using Mapeamento.Domain.Interfaces;

namespace Mapeamento.Application.Services;
public class PontoTuristicoService : IPontoTuristicoService
{
    private readonly IPontoTuristicoRepository _repository; 

    public PontoTuristicoService(IPontoTuristicoRepository repository)
    {
        _repository = repository;
    }

    public async Task<(IEnumerable<PontoTuristicoResponseDTO> Items, int contaRegistros)> ListarPontosTuristicosAsync(int pagina, int tamanhoPagina, string? busca)
    {
        var (entidades, total) = await _repository.ListarPontosTuristicosAsync(pagina, tamanhoPagina, busca);

        var dtos = entidades.Select(e => e.toDTO());

        return (dtos, total);
    }

    public async Task<PontoTuristicoResponseDTO?> BuscarPorIdAsync(int id)
    {
        var ponto = await _repository.BuscarPorIdAsync(id);
        return ponto?.toDTO();
    }

    public async Task CadastrarPontoTuristicoAsync(PontoTuristicoRequestDTO request)
    {
        if (request.Descricao.Length > 100)
        {
            throw new ArgumentException("A descrição deve conter no máximo 100 caracteres.");
        }
        
        var entidade = request.ToEntity();
        await _repository.CadastrarPontoTuristicoAsync(entidade);
    }   

    public async Task<IEnumerable<Estado>> ListarEstadosAsync()
    {
        return await _repository.ListarEstadosAsync();
    }
}