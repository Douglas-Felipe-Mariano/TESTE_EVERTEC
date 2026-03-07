export interface Estado{
    id:     number;
    nome:   string;
    sigla:  string;
}

export interface PontoTuristico {
    id:          number;
    nome:        string;
    descricao:   string;
    localizacao: string;
    cidade:      string;
    estadoId:    number;
    estado?:     Estado;
    dataCriacao: string;
}

export interface PontoTuristicoPaginado {
    itens:          PontoTuristico[];
    contaRegistros: number;
    pagina:         number;
    tamanhoPagina:  number;
}