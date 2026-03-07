using Mapeamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mapeamento.Infrastructure.Configuration;

public class PontoTuristicoConfiguration : IEntityTypeConfiguration<PontoTuristico>
{
    public void Configure(EntityTypeBuilder<PontoTuristico> builder)
    {
        builder.ToTable("PONTOS_TURISTICOS");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nome).HasMaxLength(255).IsRequired();
        builder.Property(e => e.Descricao).HasMaxLength(100).IsRequired();
        builder.Property(e => e.Localizacao).HasMaxLength(255).IsRequired();
        builder.Property(p => p.Cidade).HasMaxLength(60).IsRequired();

        builder.HasData(
           new PontoTuristico
            {
                Id = 1,
                Nome = "Cristo Redentor",
                Descricao = "Estátua icônica de Jesus Cristo, uma das maravilhas do mundo moderno.", 
                Localizacao = "Topo do Morro do Corcovado",
                Cidade = "Rio de Janeiro",
                EstadoId = 19, 
                DataCriacao = new DateTime(2024, 1, 1, 10, 0, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 2,
                Nome = "Avenida Paulista",
                Descricao = "Principal centro financeiro e cultural de São Paulo, com museus e eventos.", 
                Localizacao = "Região Central da cidade",
                Cidade = "São Paulo",
                EstadoId = 25, 
                DataCriacao = new DateTime(2024, 1, 1, 10, 0, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 3,
                Nome = "Serra do Cipó",
                Descricao = "Parque Nacional com cachoeiras, trilhas e biodiversidade exuberante.", 
                Localizacao = "MG-010, Serra do Cipó",
                Cidade = "Santana do Riacho",
                EstadoId = 13, 
                DataCriacao = new DateTime(2024, 1, 2, 11, 0, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 4,
                Nome = "Pelourinho",
                Descricao = "Centro histórico de Salvador com arquitetura colonial preservada.", 
                Localizacao = "Centro Histórico",
                Cidade = "Salvador",
                EstadoId = 5, 
                DataCriacao = new DateTime(2024, 1, 3, 9, 0, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 5,
                Nome = "Pantanal",
                Descricao = "Maior planície alagável do mundo com biodiversidade única.", 
                Localizacao = "Região Centro-Oeste",
                Cidade = "Corumbá",
                EstadoId = 12, 
                DataCriacao = new DateTime(2024, 1, 4, 8, 0, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 6,
                Nome = "Cataratas do Iguaçu",
                Descricao = "Conjunto de quedas d'água espetaculares na fronteira com Argentina.", 
                Localizacao = "Parque Nacional do Iguaçu",
                Cidade = "Foz do Iguaçu",
                EstadoId = 16, 
                DataCriacao = new DateTime(2024, 1, 5, 7, 0, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 7,
                Nome = "Teatro Amazonas",
                Descricao = "Casa de ópera histórica no coração da Amazônia.", 
                Localizacao = "Centro de Manaus",
                Cidade = "Manaus",
                EstadoId = 4, 
                DataCriacao = new DateTime(2024, 1, 6, 14, 0, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 8,
                Nome = "Lençóis Maranhenses",
                Descricao = "Parque nacional com dunas de areia branca e lagoas cristalinas.", 
                Localizacao = "Parque Nacional dos Lençóis Maranhenses",
                Cidade = "Barreirinhas",
                EstadoId = 10, 
                DataCriacao = new DateTime(2024, 1, 7, 12, 0, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 9,
                Nome = "Centro Histórico de Ouro Preto",
                Descricao = "Cidade colonial com arquitetura barroca e história da mineração.", 
                Localizacao = "Centro da cidade",
                Cidade = "Ouro Preto",
                EstadoId = 13, 
                DataCriacao = new DateTime(2024, 1, 8, 15, 0, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 10,
                Nome = "Jericoacoara",
                Descricao = "Praia paradisíaca com dunas, lagoas e pôr do sol inesquecível.", 
                Localizacao = "Parque Nacional de Jericoacoara",
                Cidade = "Jericoacoara",
                EstadoId = 6, 
                DataCriacao = new DateTime(2024, 1, 9, 16, 0, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 11,
                Nome = "Ilha de Fernando de Noronha",
                Descricao = "Arquipélago vulcânico com praias paradisíacas e vida marinha rica.", 
                Localizacao = "Arquipélago oceânico",
                Cidade = "Fernando de Noronha",
                EstadoId = 17, 
                DataCriacao = new DateTime(2024, 1, 10, 13, 0, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 12,
                Nome = "Aparados da Serra",
                Descricao = "Cânions espetaculares com paisagens de tirar o fôlego.", 
                Localizacao = "Parque Nacional dos Aparados da Serra",
                Cidade = "Cambará do Sul",
                EstadoId = 21, 
                DataCriacao = new DateTime(2024, 1, 11, 11, 0, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 13,
                Nome = "Brasília",
                Descricao = "Capital federal com arquitetura modernista única no mundo.", 
                Localizacao = "Plano Piloto",
                Cidade = "Brasília",
                EstadoId = 7, 
                DataCriacao = new DateTime(2024, 1, 12, 10, 0, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 14,
                Nome = "Bonito",
                Descricao = "Destino de ecoturismo com rios cristalinos e cavernas impressionantes.", 
                Localizacao = "Região da Serra da Bodoquena",
                Cidade = "Bonito",
                EstadoId = 12, 
                DataCriacao = new DateTime(2024, 1, 13, 9, 30, 0),
                Status = true
            },
            new PontoTuristico
            {
                Id = 15,
                Nome = "Balneário Camboriú",
                Descricao = "Praia urbana moderna com arranha-céus e vida noturna agitada.", 
                Localizacao = "Orla marítima",
                Cidade = "Balneário Camboriú",
                EstadoId = 24, 
                DataCriacao = new DateTime(2024, 1, 14, 17, 0, 0),
                Status = true
            }
        );
    }   
}
