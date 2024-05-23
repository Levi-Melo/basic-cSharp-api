# Basic C# API

Esta API é um projeto básico desenvolvido em C# para demonstrar conceitos fundamentais de programação web, incluindo a criação de endpoints RESTful, manipulação de solicitações HTTP e resposta, além de integração com um banco de dados SQL  .

## Entidades Principais

### Produto

O produto é a principal entidade deste sistema, contendo informações como ID, nome, preço e categoria.

### Categoria

As categorias permitem agrupar produtos por tipo, como eletrônicos, roupas, etc., contendo informações como ID e nome.

## Bibliotecas Utilizadas

- **AWSSDK.S3 (Versão 3.7.307.13)**: Esta biblioteca permite a integração com o Amazon Web Services Simple Storage Service (S3), permitindo operações como upload, download e gerenciamento de arquivos.
- **BCrypt.Net-Next (Versão 4.0.3)**: Uma implementação robusta e segura do algoritmo BCrypt para hashing de senhas, ideal para autenticação de usuários.
- **MailKit (Versão 4.4.0)**: Uma biblioteca poderosa para envio de emails através de vários protocolos, como SMTP, IMAP e POP3.
- **Microsoft.AspNetCore.Authentication.JwtBearer (Versão 8.0.3)**: Permite a implementação de autenticação JWT (JSON Web Tokens) em aplicações ASP.NET Core, facilitando a criação de APIs seguras.
- **Microsoft.AspNetCore.SignalR.Common (Versão 8.0.4)**: Oferece funcionalidades para comunicação em tempo real entre clientes e servidores, suportando diferentes protocolos.
- **Microsoft.EntityFrameworkCore.Design (Versão 8.0.3)**: Facilita o design e a configuração do Entity Framework Core, um ORM (Object-Relational Mapper) para.NET.
- **Npgsql.EntityFrameworkCore.PostgreSQL (Versão 8.0.2)**: Um provedor de EF Core para PostgreSQL, permitindo o uso do Entity Framework Core com bancos de dados PostgreSQL.
- **Swashbuckle.AspNetCore (Versão 6.5.0)**: Integração com o Swagger para documentação automática de APIs RESTful, tornando-as mais fáceis de consumir.
- **Swashbuckle.AspNetCore.Annotations (Versão 6.5.0)**: Estende a funcionalidade do Swashbuckle para incluir anotações de Swagger, melhorando a documentação das APIs.
- **System.IdentityModel.Tokens.Jwt (Versão 7.5.1)**: Biblioteca para trabalhar com tokens JWT, útil para autenticação e autorização em aplicações web.

## Camadas da Aplicação

A aplicação segue a arquitetura DDD (Domain-Driven Design), ultilizando camdadas de:

- **Controller**: Manipula as solicitações HTTP, interage com a Facade e retorna respostas ao cliente.
- **Facade**: Representa uma camada para abstração entre *Controller* e *Usecase*, podendo apresentar conversão de dados.
- **Usecase**: Representa a implementação de lógica de negócios associada aos dominios existentes.
- **Repository**: Consumida pelos usecases, representa toda interação com banco de dados trazendo abstração para o usecase.
- **Service**: Representa toda lógica que não pertence a um dominio especidifico e pode ser reaproveitado futuramente.

## Como Usar

### Pré-requisitos

-.NET Core SDK instalado
- PostgreSQL rodando localmente ou em um servidor remoto

### Instalação

1. Clone este repositório:

```bash
git clone https://github.com/Levi-Melo/basic-cSharp-api.git
```
2. Abra o projeto no Visual Studio ou outra IDE suportada pelo.NET Core.

3. Configure o banco de dados SQL Server conforme necessário.

### Executando a Aplicação

- No terminal, navegue até o diretório do projeto e execute:

``` bash
dotnet run
```

## Contribuição

Contribuições são sempre bem-vindas Se você encontrar algum bug ou deseja adicionar novos recursos, sinta-se à vontade para abrir um issue ou fazer um fork do projeto e enviar um Pull Request.

## Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.
