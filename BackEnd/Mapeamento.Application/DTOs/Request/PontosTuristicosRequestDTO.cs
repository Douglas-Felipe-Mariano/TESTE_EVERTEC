using System.Security.Cryptography.X509Certificates;

namespace Mapeamento.Application.DTOs;

public record PontosTuristicosRequestDTO(
    
    String Nome
   ,String Descricao
   ,String Localizacao
   ,String Cidade
   ,int    EstadoId

);