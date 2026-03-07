using Mapeamento.Domain.Entities;

namespace Mapeamento.Domain.Interfaces;

public interface IPontoTuristicoRepository
{
    Task<(List<PontoTuristico> Items, int contaRegistros)> ListarPontosTuristicosAsync(int pagina, int tamanhoPagina, string? busca);

    Task<PontoTuristico?> BuscarPorIdAsync(int id);

    Task CadastrarPontoTuristicoAsync(PontoTuristico pontoTuristico);
    
    Task<IEnumerable<Estado>> ListarEstadosAsync();

    Task AtualizarAsync(PontoTuristico ponto);
}
