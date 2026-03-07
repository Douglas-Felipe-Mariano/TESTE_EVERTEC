namespace Mapeamento.Domain.Entities;

public class Estado
{
    public int    Id {get; set;}
    public string Nome {get; set;}                                          = string.Empty;
    public string Sigla {get; set;}                                         = string.Empty;
    public virtual ICollection<PontoTuristico> PontosTuristicos {get; set;} = new List<PontoTuristico>();
}
