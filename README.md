# TechRepair

## Identificação do projeto

TechRepair é a designação do projeto de gestão de cibersegurança implementado no repositório atual. A aplicação principal está na pasta `CyberGuard/` e corresponde à solução ASP.NET Core MVC de base tecnológica e de dados para a gestão de ativos, incidentes, vulnerabilidades e relatórios de segurança.

## Descrição da aplicação

A aplicação TechRepair/CyberGuard foi desenvolvida para organizar e centralizar o domínio de cibersegurança numa organização. Nesta fase, o projeto concentra-se na estrutura base da solução, no modelo de domínio, no schema SQLite, na manutenção da integridade dos dados e na apresentação inicial da aplicação.

A implementação atual inclui:

- modelo de entidades para empresas, equipamentos, técnicos, incidentes, vulnerabilidades, intervenções, relatórios e registos de atividade;
- contexto EF Core para SQLite;
- validações de domínio e de associações;
- estrutura MVC com layout e página inicial personalizada;
- documentação de requisitos e arquitetura.

Nesta fase não existem módulos funcionais de CRUD completos nem autenticação, dashboards ou monitorização em tempo real.

## Tecnologias utilizadas

- ASP.NET Core MVC
- .NET 10 (`net10.0`)
- C#
- Entity Framework Core
- SQLite
- HTML, CSS e JavaScript
- Bootstrap/CSS customizado em `CyberGuard/wwwroot/css/site.css`

## Requisitos de instalação

Antes de executar a aplicação, confirme que o ambiente tem instalado:

- .NET SDK 10 ou compatível;
- VS Code ou outra IDE com suporte ao .NET;
- acesso à linha de comandos do .NET.

## Instruções de execução no VS Code

1. Abra a pasta do repositório no VS Code.
2. Abra o terminal integrado.
3. Navegue para a pasta da aplicação:

```powershell
cd CyberGuard
```

4. Execute os comandos de restauração e execução:

```powershell
dotnet restore
dotnet tool restore
dotnet ef database update
dotnet run
```

5. Aguarde a compilação e abra o URL indicado no terminal, normalmente em `https://localhost:<porta>`.

## Comandos necessários do .NET

Os comandos que devem ser usados neste projeto são:

```powershell
dotnet restore
dotnet tool restore
dotnet build
dotnet ef database update
dotnet run
```

Se for necessário criar uma nova migração:

```powershell
dotnet ef migrations add NomeDaMigracao
```

Para aplicar migrações manualmente:

```powershell
dotnet ef database update
```

## Localização da base de dados SQLite

A base de dados SQLite encontra-se na pasta da aplicação:

- `CyberGuard/cyberguard.db`

A string de ligação configurada em `CyberGuard/appsettings.json` é:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=cyberguard.db;Foreign Keys=True"
}
```

## Procedimentos de criação ou atualização da base de dados

A criação e atualização da base de dados são geridas pelo Entity Framework Core.

### Verificar o estado atual

```powershell
dotnet ef database update
```

### Criar uma nova migração

```powershell
dotnet ef migrations add Inicial
```

### Aplicar migrações

```powershell
dotnet ef database update
```

O ficheiro de configuração do EF Core está em `CyberGuard/dotnet-tools.json`, e o projeto já inclui os pacotes `Microsoft.EntityFrameworkCore.Sqlite`, `Design` e `Tools`.

## Estrutura de pastas

```text
AulaC-/
├── README.md
├── CyberGuard/
│   ├── Program.cs
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   ├── CyberGuard.csproj
│   ├── cyberguard.db
│   ├── dotnet-tools.json
│   ├── Controllers/
│   │   └── HomeController.cs
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Documentation/
│   │   ├── 01-Requisitos.md
│   │   ├── 02-Diagrama-ER.md
│   │   ├── 03-Modelo-Relacional.md
│   │   ├── 04-Dicionario-Dados.md
│   │   ├── 05-Regras-Negocio.md
│   │   ├── 05-Documentacao-Tecnica.md
│   │   └── 06-Validacao-Entrega.md
│   ├── Migrations/
│   ├── Models/
│   │   ├── BaseEntity.cs
│   │   ├── Empresa.cs
│   │   ├── Equipamento.cs
│   │   ├── Tecnico.cs
│   │   ├── Incidente.cs
│   │   ├── Vulnerabilidade.cs
│   │   ├── Intervencao.cs
│   │   ├── RelatorioSeguranca.cs
│   │   ├── RegistoAtividade.cs
│   │   ├── Enums.cs
│   │   └── ErrorViewModel.cs
│   ├── Services/
│   │   └── BusinessValidationService.cs
│   ├── ViewModels/
│   │   └── BaseViewModel.cs
│   ├── Views/
│   │   ├── Home/
│   │   │   ├── Index.cshtml
│   │   │   └── Privacy.cshtml
│   │   └── Shared/
│   │       ├── _Layout.cshtml
│   │       ├── _ValidationScriptsPartial.cshtml
│   │       └── Error.cshtml
│   ├── wwwroot/
│   │   ├── css/
│   │   │   └── site.css
│   │   ├── js/
│   │   │   └── site.js
│   │   └── lib/
│   └── obj/
└── DbAudit/
```

## Funcionalidades disponíveis

No estado atual da implementação, as funcionalidades disponíveis são as seguintes:

- estrutura principal da aplicação ASP.NET Core MVC;
- configuração do contexto EF Core com SQLite;
- gestão do modelo de domínio de segurança informática;
- entidades para empresas, equipamentos, técnicos, incidentes, vulnerabilidades, intervenções, relatórios e registos de atividade;
- regras de negócio definidas em `BusinessValidationService`;
- página inicial e layout personalizados;
- base de dados criada e mantida em SQLite;
- documentação técnica e de análise do sistema.

Estas capacidades correspondem à primeira fase do projeto, sendo preparatórias para extensões futuras sem introduzir CRUD completo ou módulos funcionais adicionais.

## Validação no ambiente utilizado

Os comandos acima foram validados diretamente no ambiente atual com sucesso:

```powershell
Set-Location "e:\escola\github\vers1\AulaC-\CyberGuard"
dotnet restore
dotnet build
dotnet tool restore
dotnet ef database update --no-build
```

Resultado verificado:

- `dotnet restore` concluído com sucesso;
- `dotnet build` concluído com sucesso;
- `dotnet tool restore` restaurou `dotnet-ef`;
- `dotnet ef database update --no-build` confirmou que a base de dados está atualizada e não há migrações pendentes.

## Documentação do projeto

A documentação complementar está na pasta `CyberGuard/Documentation/` e inclui requisitos, diagramas, dicionário de dados, regras de negócio, validação e documentação técnica.

