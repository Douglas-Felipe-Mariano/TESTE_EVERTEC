## Como Executar

### Pré-requisitos
- .NET 10 SDK
- SQL Server

# Passos para Execução

## Configurações do Banco de dados
A aplicação está configurada para utilizar o SQL Server (LocalDB) por padrão, visando a facilidade de execução.

String de Conexão Padrão:
``` bash
Server=(localdb)\mssqllocaldb;Database=MapeamentoDB;Trusted_Connection=True;
```

  
 Se o seu ambiente utilizar uma instância diferente (ex: .\SQLEXPRESS), você deve ajustar a ConnectionString no seguinte arquivo:

Caminho: [Mapeamento.API/appsettings.json](Mapeamento.API/appsettings.json)
``` bash
"ConnectionStrings": {
  "DefaultConnection": "Server=SUA_INSTANCIA;Database=MapeamentoDB;Trusted_Connection=True;TrustServerCertificate=True;"
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

Execute as migrations para criar e popular o banco de dados
```bash
dotnet ef database update --project Mapeamento.Infrastructure --startup-project Mapeamento.API
```

Inicie o projeto
```bash
dotnet run --project Mapeamento.API
```

A API estará disponível em: http://localhost:5287

### Swagger
A documentação da API via Swagger estará disponivel em: http://localhost:5287/swagger/index.html

> **Importante**: O banco de dados será criado automaticamente na primeira execução, incluindo todas as tabelas e dados iniciais de 15 pontos turísticos, e os 27 estados, sem necessidade de configuração prévia.

