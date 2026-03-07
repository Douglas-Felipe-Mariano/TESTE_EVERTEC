
using Mapeamento.Application.DTOs;
using Mapeamento.Application.DTOs.Response;
using Mapeamento.Domain.Entities;

namespace Mapeamento.Application.Mappers;

public static class PontoTuristicoMapper
{
    public static PontoTuristico ToEntity(this PontoTuristicoRequestDTO requestDTO)
    {
        return new PontoTuristico
        {
            Nome        = requestDTO.Nome ?? string.Empty,
            Descricao   = requestDTO.Descricao ?? string.Empty,
            Localizacao = requestDTO.Localizacao ?? string.Empty,
            Cidade      = requestDTO.Cidade ?? string.Empty,
            EstadoId    = requestDTO.EstadoId ?? 0,
            DataCriacao = DateTime.Now,
            Status      = true
        };
    }

    public static PontoTuristicoResponseDTO ToDTO(this PontoTuristico entity)
    {
        return new PontoTuristicoResponseDTO(
            entity.Id
           ,entity.Nome
           ,entity.Descricao
           ,entity.Localizacao
           ,entity.Cidade
           ,entity.EstadoId
           ,entity.Estado?.Nome ?? "N/A"
           ,entity.DataCriacao
        );
    }

}
