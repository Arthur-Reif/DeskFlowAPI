# 🎧 DeskFlow API — Gestão de Chamados e Helpdesk de TI

## Autores : Arthur Reif e Ricardo Bruch

## 🎯 Sobre o Projeto
A **DeskFlow API** é uma Web API RESTful construída em .NET Core 10 utilizando Entity Framework Core e SQL Server. O sistema automatiza o gerenciamento de chamados de suporte técnico, histórico de interações e acompanhamento de status do atendimento.

## 📦 Entidades
- **Categoria**: Agrupa os chamados por tipo (ex.: Infraestrutura, Software).
- **Chamado**: Pedido de suporte aberto por um solicitante, com título, descrição, prioridade e status. Pertence a uma categoria.
- **Interação**: Mensagem registrada dentro de um chamado, com autor e texto, formando o histórico do atendimento.

## 🛠️ Tecnologias Utilizadas
- .NET Core 10 / Web API
- Entity Framework Core 10
- SQL Server
- Swagger / OpenAPI

## 🚀 Como Executar a Aplicação

### Pré-requisitos
- .NET SDK 10 (ou superior)
- SQL Server em execução (LocalDB, SQL Server Express ou Docker)

### Passo a Passo

**1. Clone este repositório:**

```bash
git clone https://github.com/Arthur-Reif/DeskFlowAPI
```

**2. Acesse a pasta do projeto:**

```bash
cd DeskFlowAPI
```

**3. Configure a Connection String no `appsettings.json`:**

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=DeskFlowAPI;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

**4. Crie o banco de dados com as Migrations:**

```bash
dotnet ef database update
```

**5. Execute a API:**

```bash
dotnet run
```

**6. Acesse o Swagger para testar os endpoints:**

```
http://localhost:5257/swagger
```

## 🧠 Ciclo de Vida

### Chamado
- **Aberto**: Chamado registrado pelo solicitante.
- **EmAndamento**: Suporte em atendimento ao chamado.
- **Fechado**: Chamado encerrado com texto de solução.

### Categoria
- **Criada**: Cadastrada com um nome.
- **Atualizada**: O nome pode ser alterado a qualquer momento.
- **Excluída**: Só pode ser removida se não tiver chamados vinculados.

### Interação
- **Registrada**: Adicionada a um chamado com autor e mensagem, formando o histórico do atendimento.
- **Removida**: Quando o chamado é excluído, as interações dele são excluídas junto.

## 🧱 Arquitetura em Camadas
- **Controllers**: Recebem as requisições HTTP e definem os Status Codes.
- **Services**: Contêm as regras de negócio e validação dos status.
- **Repositories**: Executam comandos e consultas de banco via EF Core.
- **Middlewares**: Tratamento e padronização de erros globais da API.

## 🎥 Vídeo de Apresentação
<!-- vou por dps -->