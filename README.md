# Sistema de Mapeamento de Pontos Turísticos

Sistema completo para cadastro e gerenciamento de pontos turísticos brasileiros.

## Arquitetura

- **BackEnd**: API REST em .NET 10 
- **FrontEnd**: Interface React com TypeScript

## Tecnologias 

### Frontend
- **React 18** com TypeScript
- **React Router** para navegação
- **Axios** para comunicação HTTP
- **Lucide React** para ícones
- **CSS customizado** com variáveis

### Backend
- **.NET 10** (LTS)
- **Entity Framework Core 10.0.3**
- **SQL Server** com LocalDB
- **Swagger/OpenAPI** para documentação
- **Clean Architecture** (DDD)

### Frontend (`/frontend`)
```
src/
├── components/   # Componentes reutilizáveis (Header, Footer, Pagination, etc.)
├── hooks/        # Custom Hooks para centralizar lógica de estado e API
├── interfaces/   # Tipagens TypeScript para contratos de dados
├── pages/        # Páginas principais (Listagem, Cadastro)
└──services/      # Configuração do Axios e comunicação com API
```

### Backend (`/BackEnd`) 
```
├── Mapeamento.API/            # Controllers e configuração da aplicação
├── Mapeamento.Application/    # Services, DTOs e lógica de aplicação  
├── Mapeamento.Domain/         # Entidades e interfaces de negócio
└── Mapeamento.Infrastructure/ # Persistência, Context e Migrations
```

## Funcionalidades

- CRUD completo de pontos turísticos
- Listagem com paginação e navegação
- Busca por nome, localização ou descrição
- Relacionamento com estados brasileiros
- Soft delete (exclusão lógica)
- Interface responsiva
- Confirmações para exclusão
- Carregamento dinâmico de cidades por estado



# Como rodar o projeto
## Clonando o Repositório
Antes de qualquer coisa é necesário clonar o projeto do gitHub para sua maquina local, é possivel fazer isso com o comando
```bash
git clone https://github.com/Douglas-Felipe-Mariano/TESTE_EVERTEC.git
```

Após terminar de clonar o projeto para seu ambiente local é necessario executar as aplicações individualmente, elas estão como frontend e BackEnd ambas dentro deste repositório.

## Execução das aplicações

Para execução dos projetos, deixei instruções em um arquivo chamado README.md na pasta pasta raiz de cada aplicação, segue os caminhos:

- Caminho para o README.md do FrontEnd: [README.md](/frontend//README.md)

- Caminho para o README.md do BackEnd: [README.md](/BackEnd/README.md)