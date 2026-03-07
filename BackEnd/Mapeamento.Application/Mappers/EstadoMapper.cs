using Mapeamento.Application.DTOs.Response;
using Mapeamento.Domain.Entities;

namespace Mapeamento.Application.Mappers;

public static class EstadoMapper
{
    public static EstadoResponseDTO ToDTO(this Estado entity)
    {
        return new EstadoResponseDTO(
            entity.Id,
            entity.Nome,
            entity.Sigla
        );
    }
}
