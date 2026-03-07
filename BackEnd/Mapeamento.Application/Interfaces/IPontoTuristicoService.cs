namespace Mapeamento.Application.Interfaces;

public interface IPontoTuristicoService
{
    Task<(IEnumerable<PontoTuristicoResponseDTO> Items, int contaRegistros)> ListarPontosTuristicosAsync(int pagina, int tamanhoPagina, string? busca);

    Task<PontoTuristicoResponseDTO?> BuscarPorIdAsync(int id);

    Task CadastrarPontoTuristicoAsync(PontoTuristicoRequestDTO requestDTO);

    Task<IEnumerable<Estado>> ListarEstadosAsync();
}
