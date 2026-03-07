using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapeamento.Domain.Entities;

namespace Mapeamento.Domain.Interfaces;

public class IPontoTuristicoRepository
{
    Task<(IEnumerable<PontoTuristico> Items, int TotalCount)> ListarPontosTuristicosAsync(int pagina, int tamanhoPagina, string? busca);

    Task<PontoTuristico?> BuscarPorIdAsync(int id);

    Task cadastarPontoTuristicoAsync(PontosTuristicos pontosTuristicos);

    Task<IEnumerable<Estado>> ListarEstadosAsync();
}
