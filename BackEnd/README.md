# Sistema de Mapeamento de Pontos Turísticos

Sistema completo para cadastro e gerenciamento de pontos turísticos brasileiros.

## Arquitetura

- **BackEnd**: API REST em .NET 10 com Clean Architecture
- **FrontEnd**: Interface React com TypeScript (em desenvolvimento)

##  Como Executar

### Pré-requisitos
- .NET 10 SDK
- SQL Server 

### Backend
```bash
cd BackEnd/Mapeamento.API
dotnet run
```

A API estará disponível em: http://localhost:5287

> **Importante**: O banco de dados é criado automaticamente na primeira execução, incluindo todas as tabelas e dados iniciais de 15 pontos turísticos. Não é necessário executar comandos adicionais!

### Swagger
Acesse: http://localhost:5287 para ver a documentação da API

## Tecnologias

### Backend
- .NET 10
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI
- Clean Architecture

### Frontend
- React 18
- TypeScript
- Axios
- RouterDOM

## Funcionalidades

- ✅ CRUD completo de pontos turísticos
- ✅ Listagem com paginação
- ✅ Busca por nome, localização ou descrição
- ✅ Relacionamento com estados brasileiros
- ✅ Soft delete (exclusão lógica)
- ✅ Dados iniciais de 15 pontos turísticos


