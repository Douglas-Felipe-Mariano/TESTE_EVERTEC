namespace Mapeamento.Application.DTOs;

public record PontoTuristicoRequestDTO(
    
    string Nome
   ,string Descricao
   ,string Localizacao
   ,string Cidade
   ,int    EstadoId

);