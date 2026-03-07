using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        modelBuilder.Entity<PontoTuristico>(entity =>
        {
            entity.Property(e => e.Descricao).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Nome).IsRequired();
            entity.Property(e => e.Localizacao).IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}
