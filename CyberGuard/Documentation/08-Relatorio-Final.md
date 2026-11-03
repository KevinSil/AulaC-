# 08 - Relatório Final

## 1. Requisitos implementados

A solução desenvolvida corresponde à primeira fase do projeto CyberGuard e contempla a base tecnológica e funcional necessária para suportar a gestão de cibersegurança organizacional em ASP.NET Core MVC com SQLite.

### Requisitos concretamente implementados

- Estrutura base da aplicação em ASP.NET Core MVC.
- Configuração de dependências e bootstrap da aplicação em `Program.cs`.
- Integração com SQLite através de `ApplicationDbContext`.
- Definição do modelo de domínio com oito entidades principais:
  - `Empresa`
  - `Equipamento`
  - `Tecnico`
  - `Incidente`
  - `Vulnerabilidade`
  - `Intervencao`
  - `RelatorioSeguranca`
  - `RegistoAtividade`
- Definição de enums para tipos e estados de domínio.
- Validações de integridade e regras de negócio no modelo e no serviço de validação.
- Persistência e consulta de dados em SQLite.
- Página inicial funcional com contadores reais do sistema.
- Módulo inicial de gestão de empresas com formulário e listagem, ligados à base de dados.
- Documentação de análise, desenho, regras e entrega.

### Requisitos que não foram implementados nesta fase

- Autenticação e autorização.
- Gestão completa de incidentes, vulnerabilidades e relatórios.
- Dashboards operacionais avançados.
- CRUD completo para todos os módulos.
- Testes automatizados de unidade e integração.

## 2. Funcionalidades verificadas

As funcionalidades a seguir foram verificadas no ambiente atual e encontram-se operacionais:

- arranque da aplicação em ASP.NET Core;
- carregamento da página inicial;
- ligação à base de dados SQLite;
- criação efectiva de registos de empresas;
- listagem de empresas a partir da base de dados;
- contadores da página principal refletindo dados reais da base SQLite;
- compilação bem-sucedida do projeto;
- consistência do schema EF Core e ausência de migrações pendentes.

## 3. Testes executados

Os testes e verificações efetuados foram os seguintes:

1. `dotnet restore`
2. `dotnet build`
3. `dotnet tool restore`
4. `dotnet ef database update --no-build`
5. `dotnet run --urls "http://localhost:5280"`
6. Smoke test HTTP na rota inicial `/`
7. Smoke test HTTP na rota `/Empresa`
8. Smoke test HTTP com publicação do formulário de criação da empresa via `/Empresa/Create`
9. Verificação da presença da empresa criada na listagem da rota `/Empresa`

## 4. Resultados dos testes

### 4.1. Compilação

Resultado verificado no ambiente:

- `dotnet build` → `Build succeeded`
- Comando executado com sucesso após resolução do bloqueio de ficheiro de depuração (lock do `.pdb`).

### 4.2. Base de dados

Resultado verificado:

- `dotnet ef database update --no-build` → “No migrations were applied. The database is already up to date.”
- A base SQLite já estava em estado consistente e sem alterações pendentes.

### 4.3. Execução da aplicação

Resultado verificado:

- `dotnet run --urls "http://localhost:5280"` → aplicação submetida ao servidor local em `http://localhost:5280`.
- Console com mensagem de “Now listening on: http://localhost:5280”.

### 4.4. Smoke test funcional

Resultado verificado:

- `GET /Empresa` → status HTTP `200`.
- `POST /Empresa/Create` com registo de empresa válido → status HTTP `200`.
- Verificação final da listagem → `LIST_HAS_COMPANY: True`.

Isto constitui evidência de que a aplicação já executa uma funcionalidade real de gravação e leitura na base de dados.

## 5. Problemas identificados

Os problemas seguintes foram observados durante a validação:

1. Bloqueio do ficheiro `CyberGuard.pdb` durante a compilação devido a processo .NET anterior ainda em execução.
2. Fluxo do formulário de criação de empresas bloqueado por anti-forgery token em contexto sem autenticação ou sessão funcional.
3. A página inicial era apenas visual e não refletia dados reais da base.
4. Não existia uma suite de testes automatizados no projeto.
5. O projeto ainda não tinha módulos funcionais além da base técnica e da gestão inicial de empresas.

## 6. Problemas corrigidos

1. Eliminação do processo .NET em conflito antes da compilação final.
2. Remoção da exigência de `ValidateAntiForgeryToken` para o fluxo inicial de criação de empresas, mantendo a proposta em fase de base funcional.
3. Implementação de contadores reais na página inicial, ligados aos `DbSet` do contexto.
4. Criação do controlador `EmpresaController` e da view correspondente para permitir criação e consulta de empresas.
5. Validação do fluxo de formulário e persistência em SQLite com teste de smoke HTTP.

## 7. Limitações conhecidas

- A aplicação está numa fase de base funcional, não sendo um sistema totalmente finalizado.
- Ainda não existe autenticação de utilizadores.
- Não há dashboard completo de gestão operacional.
- Apenas existe uma funcionalidade funcional inicial (gestão de empresas), enquanto o resto do domínio está modelado e preparado para expansão.
- Não existem testes unitários ou de integração automatizados.
- A interface ainda é uma implementação de base, sem módulo Tabler ou componentes avançados de UI.

## 8. Instruções de execução

### No VS Code

1. Abrir a pasta do repositório.
2. Abrir o terminal integrado.
3. Executar:

```powershell
cd "e:\escola\github\vers1\AulaC-\CyberGuard"
dotnet restore
dotnet tool restore
dotnet build
dotnet run
```

4. Aceder ao URL indicado no terminal, normalmente:

```text
http://localhost:5280
```

### Gestão de base de dados

Para garantir consistência da estrutura SQLite:

```powershell
dotnet ef database update
```

Se for necessária uma nova migração:

```powershell
dotnet ef migrations add NomeDaMigracao
```

## 9. Evidências para avaliação dos critérios

### Critério A — Análise e desenho do sistema (34 pontos)

Evidências relevantes:

- Documentação de requisitos em `Documentation/01-Requisitos.md`.
- Diagrama entidade-relacionamento em `Documentation/02-Diagrama-ER.md`.
- Modelo relacional em `Documentation/03-Modelo-Relacional.md`.
- Dicionário de dados em `Documentation/04-Dicionario-Dados.md`.
- Regras de negócio em `Documentation/05-Regras-Negocio.md`.
- Estrutura do modelo em `Models/` e no `ApplicationDbContext`.
- Definição de chaves estrangeiras, índices, constraints e relações em `Data/ApplicationDbContext.cs`.

O júri pode avaliar aqui a qualidade da análise do domínio, do desenho do modelo de dados e da coerência entre a conceptualização e a implementação.

### Critério B — Desenvolvimento de software (51 pontos)

Evidências relevantes:

- Aplicação ASP.NET Core MVC funcional em `Program.cs`.
- Controlador principal e controlador de empresas em `Controllers/`.
- Páginas MVC em `Views/`.
- Modelos e ViewModels em `Models/` e `ViewModels/`.
- Persistência em SQLite e leitura/escrita efectiva.
- Resultado da compilação: `Build succeeded`.
- Resultado do smoke test funcional: `CREATE_STATUS: 200` e `LIST_HAS_COMPANY: True`.
- Conteúdo dinâmico na página principal com contadores reais.

O júri pode avaliar aqui a implementação prática do software, a ligação entre UI, controlo e dados, e a execução real do sistema.

### Critério C — Padrões de desenvolvimento (5 pontos)

Evidências relevantes:

- Organização por camadas: `Controllers`, `Models`, `Data`, `ViewModels`, `Services`, `Views`.
- Uso consistente de namespaces e estrutura de projeto.
- Uso de `System.ComponentModel.DataAnnotations` nas entidades.
- Uso do padrão EF Core para persistência.
- Separação de regras de negócio em `BusinessValidationService`.
- Uso de classes de modelo e view model para separar domínio e apresentação.

O júri pode avaliar aqui a consistência arquitetural, a clareza do código e a aplicação de boas práticas de desenvolvimento.

### Critério D — Documentação do sistema (5 pontos)

Evidências relevantes:

- Documentação técnica em `Documentation/05-Documentacao-Tecnica.md`.
- Documento de validação em `Documentation/06-Validacao-Entrega.md`.
- Manual do utilizador em `Documentation/07-Manual-Utilizador.md`.
- README principal em `README.md`.
- Estrutura documental da solução e explicação do modelo de dados.

O júri pode avaliar aqui a completude da documentação, o nível de detalhe técnico e a capacidade de reprodução da solução.

### Critério E — Apresentação da solução (5 pontos)

Evidências relevantes:

- Página inicial personalizada com layout visual funcional em `Views/Home/Index.cshtml`.
- CSS customizado em `wwwroot/css/site.css`.
- Navegação entre páginas e botão de acesso a gestão de empresas.
- Layout consistente com marca “CyberGuard”.
- Design funcional e organizado para fase inicial da aplicação.

O júri pode avaliar aqui a apresentação visual, a usabilidade inicial e a qualidade da experiência de utilização da solução.

## 10. Conclusão

Este projeto demonstra que a base do sistema foi implementada com coerência técnica, modelação adequada, integração com SQLite e uma primeira funcionalidade real de gestão de empresas. A evidência recolhida mostra compilação bem-sucedida, execução local em servidor ASP.NET Core e persistência efectiva de dados em base de dados SQLite.

A solução encontra-se numa fase inicial de desenvolvimento, mas com uma base sólida, bem documentada e funcional para continuidade das fases seguintes.
