
using Mapeamento.Application.DTOs;
using Mapeamento.Domain.Entities;

namespace Mapeamento.Application.Mappers;

public static class PontoTuristicoMapper
{
    //Converte DTO para Entidade
    public static PontoTuristico ToEntity(this PontoTuristicoRequestDTO requestDTO)
    {
        return new PontoTuristico
        {
            Nome = requestDTO.Nome,
            Descricao = requestDTO.Descricao,
            Localizacao = requestDTO.Localizacao,
            Cidade = requestDTO.Cidade,
            EstadoId = requestDTO.EstadoId,
            DataCriacao = DateTime.Now,
            Status = true
        };
    }

    //Converte Entidade para DTO
    public static PontoTuristicoResponseDTO toDTO(this PontoTuristico entity)
    {
        return new PontoTuristicoResponseDTO(
            entity.Id,
            entity.Nome,
            entity.Descricao,
            entity.Localizacao,
            entity.Cidade,
            entity.Estado?.Nome ?? "N/A",
            entity.DataCriacao
        );
    }
}
