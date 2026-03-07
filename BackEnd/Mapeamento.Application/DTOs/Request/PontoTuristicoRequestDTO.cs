namespace Mapeamento.Application.DTOs;

public record PontoTuristicoRequestDTO(
    
    string?  Nome        = null
   ,string?  Descricao   = null
   ,string?  Localizacao = null
   ,string?  Cidade      = null
   ,int?    EstadoId     = null

);