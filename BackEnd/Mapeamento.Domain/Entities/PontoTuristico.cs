using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mapeamento.Domain.Entities;

public class PontoTuristico
{
    public int Id {get; set;}

    public string Nome {get; set;} = string.Empty;

    public string Descricao {get; set;} = string.Empty;

    public string Localizacao {get; set;} = string.Empty;

    public string Cidade {get; set;} = string.Empty;

    public int EstadoId {get; set;}
    public virtual Estado Estado {get; set;} = null!;

    public DateTime DataCriacao {get; set;} = DateTime.Now;

    public bool Status {get; set;} = true;
}
