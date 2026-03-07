namespace Mapeamento.Domain.Entities;

public class PontoTuristico
{
    public int      Id {get; set;}
    public string   Nome {get; set;}           = string.Empty;
    public string   Descricao {get; set;}      = string.Empty;
    public string   Localizacao {get; set;}    = string.Empty;
    public string   Cidade {get; set;}         = string.Empty;
    public virtual  Estado Estado {get; set;}  = null!;
    public DateTime DataCriacao {get; set;}    = DateTime.Now;
    public bool     Status {get; set;}         = true;
    public int      EstadoId {get; set;}
}
