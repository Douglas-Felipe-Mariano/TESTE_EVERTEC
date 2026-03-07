using Mapeamento.Application.DTOs;
using Mapeamento.Application.Interfaces;
using Mapeamento.Application.Mappers;
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
        var dtos = entidades.Select(e => e.ToDTO());
        return (dtos, total);
    }

    public async Task<PontoTuristicoResponseDTO?> BuscarPorIdAsync(int id)
    {
        var ponto = await _repository.BuscarPorIdAsync(id);
        return ponto?.ToDTO();
    }

    public async Task CadastrarPontoTuristicoAsync(PontoTuristicoRequestDTO request)
    {
        if (string.IsNullOrWhiteSpace(request.Nome))
            throw new ArgumentException("Nome é obrigatório.");
        
        if (string.IsNullOrWhiteSpace(request.Descricao))
            throw new ArgumentException("Descrição é obrigatória.");
        
        if (string.IsNullOrWhiteSpace(request.Localizacao))
            throw new ArgumentException("Localização é obrigatória.");
        
        if (string.IsNullOrWhiteSpace(request.Cidade))
            throw new ArgumentException("Cidade é obrigatória.");
        
        if (!request.EstadoId.HasValue || request.EstadoId <= 0)
            throw new ArgumentException("Estado é obrigatório.");
        
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

    public async Task AtualizarPontoTuristicoAsync(int id, PontoTuristicoRequestDTO request)
    {
        var ponto = await _repository.BuscarPorIdAsync(id);
        if (ponto == null) throw new Exception("Ponto não encontrado");

        if (!string.IsNullOrWhiteSpace(request.Descricao) && request.Descricao.Length > 100)
            throw new ArgumentException("A descrição deve conter no máximo 100 caracteres.");

        if (!string.IsNullOrWhiteSpace(request.Nome))
            ponto.Nome = request.Nome;
        
        if (!string.IsNullOrWhiteSpace(request.Descricao))
            ponto.Descricao = request.Descricao;
        
        if (!string.IsNullOrWhiteSpace(request.Localizacao))
            ponto.Localizacao = request.Localizacao;
        
        if (!string.IsNullOrWhiteSpace(request.Cidade))
            ponto.Cidade = request.Cidade;
        
        if (request.EstadoId.HasValue && request.EstadoId.Value > 0)
            ponto.EstadoId = request.EstadoId.Value;

        await _repository.AtualizarAsync(ponto);
    }

    public async Task ExcluirPontoAsync(int id)
    {
        var ponto = await _repository.BuscarPorIdAsync(id);
        if (ponto != null)
        {
            ponto.Status = false; 
            await _repository.AtualizarAsync(ponto);
        }
    }
}