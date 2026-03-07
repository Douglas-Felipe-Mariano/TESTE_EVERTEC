using Mapeamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mapeamento.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    public DbSet<PontoTuristico> PontosTuristicos { get; set; }
    public DbSet<Estado> Estados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
