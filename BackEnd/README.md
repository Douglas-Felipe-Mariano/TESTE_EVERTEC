## Como Executar

### Pré-requisitos
- .NET 10 SDK
- SQL Server

# Passos para Execução

## Configurações do Banco de dados
A aplicação está configurada para utilizar o SQL Server (LocalDB) por padrão, visando a facilidade de execução.

String de Conexão Padrão:
``` bash
"DefaultConnection": "Data Source=.;Initial Catalog=MapeamentoDB;Integrated Security=True;TrustServerCertificate=True;"
```

  
 Se o seu ambiente utilizar uma instância diferente (ex: .\SQLEXPRESS), você deve ajustar a ConnectionString no seguinte arquivo:

Caminho: [Mapeamento.API/appsettings.json](Mapeamento.API/appsettings.json)
``` bash
"ConnectionStrings": {
  "DefaultConnection": "Data Source=SUA_INSTANCIA;Initial Catalog=MapeamentoDB;Integrated Security=True;TrustServerCertificate=True;"
}
```

Caso contrario continue com a execução do projeto

## Execução do Projeto

Navegue até a pasta do projeto:
```bash
cd BackEnd
```

Restaure as dependências:
```bash
dotnet restore
```

Inicie o projeto
```bash
dotnet run --project Mapeamento.API
```

> **Importante**: O banco de dados será criado automaticamente na primeira execução, incluindo todas as tabelas e dados iniciais de 15 pontos turísticos, e os 27 estados, sem necessidade de configuração prévia.


A API estará disponível em: http://localhost:5287

## Swagger
A documentação da API via Swagger estará disponivel em: http://localhost:5287/swagger/index.html


