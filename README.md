
# ProjetoFutebol

Sistema Web para gerenciamento e exibição de dados de futebol, utilizando ASP.NET Core 8.0, arquitetura DDD e uma API RESTful como backend.

## Tecnologias Utilizadas

- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **Migrations**
- **Unit of Work**
- **Repositórios Genéricos**
- **Arquitetura DDD (Domain-Driven Design)**
- **Bootstrap 5**
- **JavaScript Vanilla**
- **HTML + Razor Pages**
- **SQL Server**

## Estrutura do Projeto

- **ProjetoFutebol.Web**: Front-end da aplicação utilizando HTML, JavaScript e Bootstrap.
- **ProjetoFutebol.WebAPI**: API que expõe os dados via endpoints RESTful.
- **ProjetoFutebol.Dominio**: Entidades de domínio e regras de negócio.
- **ProjetoFutebol.Infra**: Camada de persistência de dados, incluindo repositórios e mapeamentos.
- **ProjetoFutebol.Aplicacao**: Casos de uso, DTOs e serviços de aplicação.

A comunicação entre o front-end e o back-end é feita exclusivamente por meio de chamadas HTTP à API.

## Autenticação

A autenticação é baseada em **JWT**. É necessário se registrar e realizar o login para obter o token de acesso e conseguir utilizar os endpoints de sincronização.

### Endpoints de Autenticação

- `POST /registrar`: Registra um novo usuário.
- `POST /login`: Retorna um token JWT se as credenciais forem válidas.

## Endpoints Públicos

- `GET /areas`
- `GET /competicoes`
- `GET /equipes`
- `GET /partidas-hoje`
- `GET /competicao-especifica?codigoCompeticao={codigo}`
- `GET /time-especifico?codigoTime={codigo}`
- `GET /times-competicao?codigoCompeticao={codigo}`

## Endpoints Protegidos (necessitam token JWT)

- `POST /sincronizar-paises`
- `POST /sincronizar-competicoes`
- `POST /sincronizar-times-por-competicao?codigoCompeticao={codigo}`
- `POST /sincronizar-partidas-por-competicao?codigoCompeticao={codigo}`

Para acessar esses endpoints, envie o token no cabeçalho da requisição como:

```
Authorization: Bearer {seu_token_jwt}
```

## Execução

1. Clone o repositório
2. Configure a `connection string` no `appsettings.json`
3. Execute as migrations com:
   ```bash
   dotnet ef database update
   ```
4. Execute o projeto:
   ```bash
   dotnet run --project ProjetoFutebol.API
   ```

---

Caso deseje implementar o front-end em Angular no futuro, o projeto está estruturado para fácil adaptação.
