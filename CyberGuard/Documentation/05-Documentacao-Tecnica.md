# 05 - Documentação Técnica

## 1. Descrição geral da aplicação

A aplicação CyberGuard foi implementada como uma solução ASP.NET Core MVC para apoiar a gestão da segurança informática em organizações. A estrutura atual corresponde à primeira fase do projeto, centrada na base técnica, no modelo de domínio e na persistência em SQLite, sem implementar módulos funcionais de CRUD nem fluxos de negócio completos.

No estado atual, a aplicação organiza a definição dos principais conceitos do sistema de cibersegurança:

- empresas;
- equipamentos informáticos;
- técnicos de segurança;
- incidentes;
- vulnerabilidades;
- intervenções;
- relatórios de segurança;
- registos de atividade.

A solução foi desenvolvida com foco em consistência de dados, validações de domínio e preparação para extensões futuras, mantendo a arquitetura MVC e o mapeamento ORM com Entity Framework Core.

## 2. Objetivos

Os objetivos desta implementação são:

- preparar a estrutura base da aplicação em ASP.NET Core MVC;
- definir o modelo de dados do domínio da cibersegurança;
- configurar a persistência em SQLite;
- garantir integridade referencial e validações de negócio ao nível do modelo e da base de dados;
- manter uma organização por camadas que permita expansão posterior sem alterar a base existente;
- servir como base de trabalho para fases seguintes do projeto, sem introduzir módulos funcionais adicionais nesta fase.

## 3. Tecnologias utilizadas

A solução utiliza as tecnologias e recursos abaixo, de acordo com o código implementado:

- ASP.NET Core MVC
- .NET 10 (`net10.0`)
- C# com nullable reference types
- Entity Framework Core
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- SQLite
- HTML, CSS e MVC Views
- Bootstrap/CSS personalizado em `wwwroot/css/site.css`

A configuração da aplicação está registada em `Program.cs`, e a string de conexão encontra-se em `appsettings.json` com o valor:

`Data Source=cyberguard.db;Foreign Keys=True`

## 4. Arquitetura MVC

A arquitetura da aplicação segue o padrão Model-View-Controller, com a seguinte organização funcional:

- `Program.cs`: ponto de entrada da aplicação e registo dos serviços.
- `Controllers/`: camada de entrada que define os controladores.
- `Models/`: entidades do domínio e modelos auxiliares.
- `Data/`: configuração do contexto EF Core.
- `ViewModels/`: modelos de apresentação.
- `Views/`: páginas MVC e layout geral.
- `wwwroot/`: recursos estáticos do cliente.
- `Services/`: serviços de validação de regras de negócio.
- `Documentation/`: documentação técnica e de análise do projeto.

No arranque da aplicação, o `Program.cs` regista:

- `AddControllersWithViews()`;
- `AddDbContext<ApplicationDbContext>()` com SQLite;
- roteamento MVC padrão;
- o middleware de erro em ambiente de produção;
- a utilização de recursos estáticos.

A rota padrão definida é:

`{controller=Home}/{action=Index}/{id?}`

Assim, a aplicação abre a página principal por meio do controlador `HomeController`.

## 5. Organização do projeto

A estrutura atual da solução é a seguinte:

```text
CyberGuard/
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── CyberGuard.csproj
├── cyberguard.db
├── Controllers/
│   └── HomeController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Documentation/
│   ├── 01-Requisitos.md
│   ├── 02-Diagrama-ER.md
│   ├── 03-Modelo-Relacional.md
│   ├── 04-Dicionario-Dados.md
│   ├── 05-Regras-Negocio.md
│   ├── 05-Documentacao-Tecnica.md
│   └── 06-Validacao-Entrega.md
├── Migrations/
├── Models/
│   ├── BaseEntity.cs
│   ├── Empresa.cs
│   ├── Equipamento.cs
│   ├── Tecnico.cs
│   ├── Incidente.cs
│   ├── Vulnerabilidade.cs
│   ├── Intervencao.cs
│   ├── RelatorioSeguranca.cs
│   ├── RegistoAtividade.cs
│   ├── Enums.cs
│   └── ErrorViewModel.cs
├── Services/
│   └── BusinessValidationService.cs
├── ViewModels/
│   ├── BaseViewModel.cs
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       ├── _ValidationScriptsPartial.cshtml
│       └── Error.cshtml
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   ├── js/
│   │   └── site.js
│   └── lib/
└── obj/
```

A solução encontra-se num estado de base funcional para organização do domínio, migrações, validação de dados e apresentação inicial da aplicação.

## 6. Estrutura da base de dados SQLite

A base de dados é gerida pelo `ApplicationDbContext`, configurado com SQLite e com `Foreign Keys=True` na connection string. O contexto expõe os seguintes `DbSet`:

- `Empresas`
- `Equipamentos`
- `Tecnicos`
- `Incidentes`
- `Vulnerabilidades`
- `Intervencoes`
- `RelatoriosSeguranca`
- `RegistosAtividade`

### Tabelas principais

#### Empresas
Armazena os dados da organização cliente e principais dados de cadastro:

- `Id`
- `Nome`
- `NIF`
- `Email`
- `Telefone`
- `Morada`
- `CodigoPostal`
- `Localidade`
- `SetorAtividade`
- `DataRegisto`
- `Ativa`
- `Observacoes`

Validações e restrições:

- `Nome` obrigatório, máximo 200 caracteres;
- `NIF` obrigatório e único, com tamanho fixo de 9 caracteres;
- `Email` obrigatório, único e com máximo de 255 caracteres;
- índice único em `NIF` e `Email`.

#### Equipamentos
Armazena o inventário dos ativos de tecnologia de uma empresa:

- `Id`
- `EmpresaId`
- `Nome`
- `TipoEquipamento`
- `Marca`
- `Modelo`
- `NumeroSerie`
- `SistemaOperativo`
- `EnderecoIP`
- `EnderecoMAC`
- `DataRegisto`
- `UltimaVerificacao`
- `Estado`
- `Observacoes`

Validações e restrições:

- `EmpresaId` obrigatório;
- `Nome` obrigatório;
- `NumeroSerie` com índice único;
- relação com `Empresa` via chave estrangeira.

#### Tecnicos
Mantém o registo dos técnicos responsáveis por segurança:

- `Id`
- `Nome`
- `Email`
- `Telefone`
- `Especialidade`
- `NivelExperiencia`
- `DataAdmissao`
- `Ativo`
- `Observacoes`

Validações e restrições:

- `Email` obrigatório e único;
- `Nome` obrigatório;
- `NivelExperiencia` com intervalo de 1 a 10.

#### Incidentes
Representa os eventos de segurança reportados:

- `Id`
- `EmpresaId`
- `EquipamentoId` (opcional)
- `TecnicoId` (opcional)
- `Titulo`
- `Descricao`
- `TipoIncidente`
- `NivelGravidade`
- `Estado`
- `DataDetecao`
- `DataResolucao` (opcional)
- `OrigemDetecao`
- `Impacto`
- `MedidasAplicadas`
- `Observacoes`

Restrições relevantes:

- `CK_Incidente_DataResolucao`: garante que a data de resolução não seja anterior à data de deteção;
- `EmpresaId`, `Titulo`, `Descricao`, `TipoIncidente`, `NivelGravidade`, `Estado` e `OrigemDetecao` são obrigatórios;
- `EquipamentoId` e `TecnicoId` são opcionais, mas podem ser associados quando existir responsável ou ativo relacionado.

#### Vulnerabilidades
Armazena falhas ou riscos reportados no ambiente:

- `Id`
- `EmpresaId`
- `EquipamentoId`
- `TecnicoId` (opcional)
- `Titulo`
- `Descricao`
- `CodigoCVE`
- `Categoria`
- `NivelRisco`
- `PontuacaoCVSS`
- `DataIdentificacao`
- `DataCorrecao` (opcional)
- `Estado`
- `Recomendacao`
- `Observacoes`

Restrições relevantes:

- `CK_Vulnerabilidade_PontuacaoCVSS`: o valor deve estar entre 0 e 10, quando preenchido;
- `CK_Vulnerabilidade_DataCorrecao`: a data de correção não pode ser anterior à data de identificação;
- `CodigoCVE` usa expressão regular para validar o padrão `CVE-YYYY-NNNN...`.

#### Intervencoes
Regista as ações técnicas executadas em resposta a incidentes ou vulnerabilidades:

- `Id`
- `TecnicoId`
- `IncidenteId` (opcional)
- `VulnerabilidadeId` (opcional)
- `DataIntervencao`
- `TipoIntervencao`
- `DescricaoTrabalho`
- `SolucaoAplicada`
- `TempoTrabalho`
- `Custo`
- `Resultado`
- `Observacoes`

Restrições relevantes:

- `CK_Intervencao_TempoTrabalho`: deve ser maior ou igual a 0;
- `CK_Intervencao_Custo`: deve ser maior ou igual a 0;
- `CK_Intervencao_AtLeastOneAssociation`: exige que a intervenção esteja associada a um incidente ou a uma vulnerabilidade;
- `TecnicoId` obrigatório.

#### RelatoriosSeguranca
Armazena a consolidação de resultados de segurança por empresa e técnico:

- `Id`
- `EmpresaId`
- `TecnicoId`
- `Titulo`
- `Descricao`
- `TipoRelatorio`
- `DataCriacao`
- `PeriodoInicio`
- `PeriodoFim` (opcional)
- `NumeroIncidentes`
- `NumeroVulnerabilidades`
- `NivelSeguranca`
- `Recomendacoes`
- `Observacoes`

Restrições relevantes:

- `CK_RelatorioSeguranca_NumeroIncidentes`: maior ou igual a 0;
- `CK_RelatorioSeguranca_NumeroVulnerabilidades`: maior ou igual a 0;
- `CK_RelatorioSeguranca_Periodo`: `PeriodoFim` não pode ser anterior a `PeriodoInicio`.

#### RegistosAtividade
Regista ações e eventos do sistema relacionadas com técnicos e empresas:

- `Id`
- `TecnicoId`
- `EmpresaId`
- `TipoAtividade`
- `Descricao`
- `EntidadeAfetada`
- `IdentificadorEntidade`
- `DataAtividade`
- `Observacoes`

## 7. Relações entre as entidades

As relações principais do modelo são as seguintes:

- `Empresa` possui muitos `Equipamentos`.
- `Empresa` possui muitos `Incidentes`.
- `Empresa` possui muitas `Vulnerabilidades`.
- `Empresa` possui muitos `RelatoriosSeguranca`.
- `Empresa` possui muitos `RegistosAtividade`.
- `Equipamento` pertence a uma `Empresa`.
- `Equipamento` pode ter muitos `Incidentes`.
- `Equipamento` pode ter muitas `Vulnerabilidades`.
- `Tecnico` pode ter muitos `Incidentes`.
- `Tecnico` pode ter muitas `Vulnerabilidades`.
- `Tecnico` pode ter muitas `Intervencoes`.
- `Tecnico` pode ter muitos `RelatoriosSeguranca`.
- `Tecnico` pode ter muitos `RegistosAtividade`.
- `Incidente` pode ter muitas `Intervencoes`.
- `Vulnerabilidade` pode ter muitas `Intervencoes`.
- `Intervencao` está associada a um `Tecnico` e pode estar relacionada com um `Incidente` ou com uma `Vulnerabilidade`.

A implementação usa navegações do tipo `ICollection` e chaves estrangeiras com `OnDelete(DeleteBehavior.Restrict)`, garantindo que a exclusão de registos principais não invalide arbitrariamente a integridade do restante modelo.

## 8. Organização dos Controllers

Atualmente, o projeto contém apenas o controlador principal:

### `HomeController`
Ficheiro: `Controllers/HomeController.cs`

Responsabilidades:

- `Index()`: devolve a página principal da aplicação;
- `Privacy()`: devolve a página de política de privacidade;
- `Error()`: devolve a página de erro com `ErrorViewModel`.

O controlador não contém endpoints CRUD nem ações para gestão de incidentes, vulnerabilidades, relatórios ou equipamentos. Este comportamento reflete a fase atual da solução, em que a base de dados e o domínio já existem, mas a camada funcional não foi implementada.

## 9. Organização dos Models e ViewModels

### Models

Os modelos de domínio encontram-se em `Models/` e representam o núcleo do negócio.

- `BaseEntity`: classe abstrata com `Id` comum a todas as entidades.
- `Empresa`: cadastro da organização cliente.
- `Equipamento`: inventário técnico da organização.
- `Tecnico`: especialista em segurança.
- `Incidente`: incidente de segurança.
- `Vulnerabilidade`: falha ou risco de segurança.
- `Intervencao`: ação técnica executada.
- `RelatorioSeguranca`: consolidação de segurança.
- `RegistoAtividade`: histórico de ações.
- `Enums.cs`: enumerações para tipos e estados do domínio.
- `ErrorViewModel`: modelo auxiliar para a página de erro.

Todos os modelos aplicam atributos de validação com `System.ComponentModel.DataAnnotations`, como `Required`, `StringLength`, `RegularExpression`, `Range`, `EmailAddress` e `Phone`.

### ViewModels

A pasta `ViewModels` contém modelos de apresentação e apoio à camada de visualização:

- `BaseViewModel`: estrutura base para páginas de apresentação com `Title`, `Description` e `CreatedAt`.

Atualmente, a solução mantém uma estrutura mínima e não implementa múltiplos ViewModels específicos por funcionalidade, porque o foco desta fase é a estrutura e a modelação base do sistema.

## 10. Serviços e regras de negócio

O serviço de negócio implementado encontra-se em `Services/BusinessValidationService.cs` e é uma classe estática, com validações reutilizáveis para o domínio.

### Métodos existentes

#### `ValidarAssociacaoIncidenteEquipamento`
Valida se o incidente pode estar associado ao equipamento informado:

- se `EquipamentoId` for nulo, aceita a associação;
- caso contrário, exige que o equipamento exista e pertença à mesma empresa do incidente.

#### `ValidarAssociacaoVulnerabilidadeEquipamento`
Valida se uma vulnerabilidade está associada ao equipamento correto:

- exige que o equipamento exista;
- compara a empresa da vulnerabilidade com a empresa do equipamento.

#### `ValidarAssociacaoIntervencao`
Valida se a intervenção possui pelo menos uma associação:

- aceita a intervenção se `IncidenteId` ou `VulnerabilidadeId` estiver preenchido.

Estas regras estão previstas na camada de serviços e acompanham a lógica de consistência exigida pelo modelo de dados. No estado atual, não existem controladores que consumam diretamente estes métodos, pelo que a sua integração funcional ainda não foi materializada em interfaces de utilizador.

## 11. Procedimentos de instalação

### Pré-requisitos

- SDK do .NET compatível com `net10.0`;
- editor ou terminal com acesso ao código da solução;
- sem necessidade de servidor SQLite externo, pois a aplicação usa o ficheiro SQLite local.

### Passos

1. Abrir a pasta da solução `CyberGuard`.
2. Restaurar os pacotes NuGet:

```bash
dotnet restore
```

3. Garantir que a base de dados SQLite local exista ou seja criada pela migração/estrutura aplicável. A base de dados padrão é `cyberguard.db` na raiz do projeto.
4. Caso seja necessário aplicar as migrações existentes:

```bash
dotnet ef database update
```

5. Confirmar que o ficheiro `cyberguard.db` foi criado e que a estrutura da base de dados foi gerada com as tabelas definidas em `ApplicationDbContext`.

## 12. Procedimentos de execução

### Compilar a aplicação

```bash
dotnet build
```

### Executar a aplicação

```bash
dotnet run
```

Durante a execução, o ASP.NET Core mostra a URL local em que a aplicação está a correr. A aplicação responde sobretudo às rotas de base MVC e às páginas da estrutura principal, como:

- `/`
- `/Home/Privacy`
- `/Home/Error`

### Validação básica

É recomendável verificar os pontos seguintes:

- compilação sem erros;
- carregamento do layout principal;
- acesso à página principal (`Index`);
- carregamento dos recursos estáticos em `wwwroot`;
- existência da base de dados SQLite e das tabelas geradas pelo EF Core.

## Conclusão

A solução CyberGuard, no seu estado atual, apresenta uma base sólida para a gestão de segurança informática em ambiente empresarial, com arquitetura MVC, persistência em SQLite, modelo de dados conceptualizado e regras de negócio definidas ao nível do domínio e da base de dados. Esta fase corresponde a uma primeira entrega estrutural e preparatória, estando pronta para evoluir para módulos funcionais mais avançados no futuro, sem perder a coerência da solução já implementada.
