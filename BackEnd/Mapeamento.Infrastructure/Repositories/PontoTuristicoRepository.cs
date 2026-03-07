using Mapeamento.Domain.Entities;
using Mapeamento.Domain.Interfaces;
using Mapeamento.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Mapeamento.Infrastructure.Repositories;

public class PontoTuristicoRepository : IPontoTuristicoRepository
{
    private readonly AppDbContext _context;

    public PontoTuristicoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<(List<PontoTuristico> Items, int contaRegistros)> ListarPontosTuristicosAsync(int pagina, int tamanhoPagina, string? busca)
    {
        var query = _context.PontosTuristicos
                            .Include(p => p.Estado)
                            .Where(p => p.Status)
                            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(busca))
        {
            query = query.Where(p => p.Nome.Contains(busca) ||
                                     p.Localizacao.Contains(busca) ||
                                     p.Descricao.Contains(busca));
        }

        var contaRegistros = await query.CountAsync();

        var items = await query.OrderByDescending(p => p.DataCriacao)
                               .Skip((pagina - 1) * tamanhoPagina)
                               .Take(tamanhoPagina)
                               .ToListAsync();

        return (items, contaRegistros);                               
    }

    public async Task CadastrarPontoTuristicoAsync(PontoTuristico pontoTuristico)
    {
        await _context.PontosTuristicos.AddAsync(pontoTuristico);
        await _context.SaveChangesAsync();
    }

    public async Task<PontoTuristico?> BuscarPorIdAsync(int id)
    {
        return await _context.PontosTuristicos
                             .Include(p => p.Estado)
                             .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Estado>> ListarEstadosAsync()
    {
        return await _context.Estados.OrderBy(e => e.Nome).ToListAsync();
    }

    public async Task AtualizarAsync(PontoTuristico ponto)
    {
        _context.PontosTuristicos.Update(ponto);
        await _context.SaveChangesAsync();
    }

}
