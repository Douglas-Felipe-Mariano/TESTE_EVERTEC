namespace Mapeamento.Application.DTOs;

public record PontoTuristicoResponseDTO(

    int Id
   ,string   Nome 
   ,string   Descricao
   ,string   Localizacao
   ,string   Cidade
   ,string   EstadoNome
   ,DateTime DataCriacao 

);