# Manual do Utilizador

## Introdução

A aplicação CyberGuard foi desenvolvida para apoiar a gestão de cibersegurança numa organização. A presente versão corresponde à primeira fase da solução, com foco na base do sistema, na estrutura de dados e na persistência em SQLite.

## Objetivo da aplicação

A plataforma permite organizar e manter a informação relacionada com:

- empresas;
- equipamentos informáticos;
- técnicos de segurança;
- incidentes;
- vulnerabilidades;
- intervenções;
- relatórios de segurança;
- registos de atividade.

## Requisitos do sistema

- Windows, macOS ou Linux com suporte ao .NET SDK 10;
- VS Code ou outra IDE com suporte ao C#;
- acesso ao terminal.

## Instalação

1. Abra a pasta do projeto no VS Code.
2. Abra o terminal integrado.
3. Navegue para a pasta da aplicação:

```powershell
cd CyberGuard
```

4. Restaure as dependências:

```powershell
dotnet restore
```

5. Restaure as ferramentas do EF Core:

```powershell
dotnet tool restore
```

## Execução

Para compilar e iniciar a aplicação:

```powershell
dotnet build
dotnet run
```

A aplicação inicia o servidor ASP.NET Core e apresenta a URL local em que está a correr. Normalmente, o endereço aparece no terminal e pode ser aberto no browser.

## Base de dados SQLite

A base de dados local encontra-se em:

`CyberGuard/cyberguard.db`

A ligação está configurada em `CyberGuard/appsettings.json` e utiliza a seguinte string:

```json
"DefaultConnection": "Data Source=cyberguard.db;Foreign Keys=True"
```

## Criação e atualização da base de dados

Para garantir que a base de dados está atualizada com as migrações existentes:

```powershell
dotnet ef database update
```

Se for necessário criar uma nova migração:

```powershell
dotnet ef migrations add NomeDaMigracao
```

## Funcionalidades disponíveis nesta fase

As capacidades disponíveis nesta entrega incluem:

- estrutura MVC da aplicação;
- persistência em SQLite;
- modelo de domínio completo;
- validadores de integridade e regras de negócio;
- página inicial personalizada e layout base;
- documentação do sistema.

## Observações

- Esta fase não inclui autenticação de utilizadores.
- Não existem módulos CRUD funcionais para todos os domínios.
- O objetivo principal desta entrega é a base técnica e documental da solução.
