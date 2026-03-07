using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mapeamento.Domain.Entities;

public class Estado
{
    public int Id {get; set;}

    public string Nome {get; set;} = string.Empty;

    public string Sigla {get; set;} = string.Empty;

    public virtual ICollection<PontosTuristicos> PontosTuristicos {get; set;} = new List<PontosTuristicos>();
}
