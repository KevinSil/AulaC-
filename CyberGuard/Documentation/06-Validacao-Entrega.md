# 06 - Validacao e Preparacao da Entrega

**Data da verificacao:** 03/11/2026  
**Projeto:** CyberGuard, ASP.NET Core MVC  
**Base de dados:** SQLite (`CyberGuard/cyberguard.db`)

## Ambito verificado

A verificacao incidiu sobre o projeto e a base de dados existentes. Nao foram recriados o projeto, o schema ou as migrations, e nao foram alterados os dados da base durante as provas. A prova negativa da constraint de datas foi executada sobre uma copia temporaria da base.

## Evidencias

| Verificacao | Resultado | Evidencia |
| --- | --- | --- |
| SDK .NET | Aprovado | `dotnet --version` devolveu `10.0.401`. |
| Compilacao MVC/Razor | Aprovado | `dotnet build -p:BaseOutputPath=<diretorio-temporario> -p:UseAppHost=false` terminou com `Build succeeded`. O output separado evita substituir ficheiros de build que ja estavam modificados no worktree. |
| Estado das migrations | Aprovado | `dotnet ef migrations list` encontrou `20261102164514_InitialCreate` e `20261102165146_AddReportPeriodConstraint` aplicadas. |
| Snapshot EF Core | Aprovado | `dotnet ef migrations has-pending-model-changes` indicou que nao existem alteracoes pendentes. |
| Tabelas SQLite | Aprovado | Foram encontradas as oito tabelas de dominio: `Empresas`, `Equipamentos`, `Tecnicos`, `Incidentes`, `Vulnerabilidades`, `Intervencoes`, `RelatoriosSeguranca` e `RegistosAtividade`. O historico de migrations tambem esta presente. |
| Integridade referencial | Aprovado | `PRAGMA foreign_key_check` devolveu zero violacoes. |
| Constraint do periodo do relatorio | Aprovado | Uma insercao com `PeriodoFim` anterior a `PeriodoInicio`, tentada numa copia temporaria, foi rejeitada por `CK_RelatorioSeguranca_Periodo`. A transacao foi revertida. |
| Rota inicial | Aprovado | `GET /` devolveu HTTP 200 e apresenta CyberGuard, sem o texto padrao `Welcome`. |
| Rota de privacidade | Aprovado | `GET /Home/Privacy` devolveu HTTP 200. |
| CSS da aplicacao | Aprovado | `GET /css/site.css` devolveu HTTP 200 com `Content-Type: text/css`. |
| Testes automatizados | Nao disponiveis | `dotnet test --no-restore` terminou sem executar testes; nao foi encontrado projeto de testes no repositorio. |

## Como repetir a verificacao

Executar a partir da raiz do repositorio no PowerShell:

```powershell
Set-Location .\CyberGuard
dotnet restore
dotnet tool restore
dotnet build
dotnet ef migrations list
dotnet ef migrations has-pending-model-changes
dotnet test
```

Para iniciar a aplicacao localmente:

```powershell
dotnet run
```

Abrir o URL indicado pelo `dotnet run`, normalmente `http://localhost:5177` ou `https://localhost:7109`, conforme o perfil escolhido.

## Estado funcional observado

- A aplicacao inicia e serve a pagina inicial e a pagina Privacy.
- A pagina inicial apresenta o estado da fundacao e as oito entidades de dominio; nao representa dados consultados da base de dados.
- Nao existem controllers CRUD, autenticacao, dashboard operacional ou fluxos de gestao nesta entrega.
- A existencia das tabelas e das migrations foi confirmada; nao foi feita prova de fluxos CRUD, pois esses fluxos nao estao implementados.

## Pendencias e limites conhecidos

1. **Suite de testes:** ainda nao existe projeto de testes automatizados. As verificacoes acima sao de compilacao, migrations, schema e smoke test HTTP; nao substituem testes unitarios ou de integracao.
2. **Tabler UI:** Tabler nao esta integrado. O projeto contem assets Bootstrap 5, mas o layout atual utiliza CSS proprio e nao carrega o stylesheet Bootstrap. A interface atual nao deve ser apresentada como uma integracao Tabler concluida.
3. **Validacoes de fluxo:** a camada `BusinessValidationService` e apenas uma estrutura inicial. Regras dependentes do contexto, como verificar se equipamento e incidente pertencem a mesma empresa, necessitam de chamadas da futura camada funcional e nao foram exercitadas por controllers ou casos de uso.
4. **Conteudo de dados:** esta verificacao validou estrutura e integridade referencial; nao avaliou a exatidao ou completude de registos de negocio existentes.

## Checklist de entrega

- [x] Projeto ASP.NET Core MVC existente preservado.
- [x] Configuracao SQLite e migrations verificadas.
- [x] Oito tabelas de dominio presentes.
- [x] Integridade referencial sem violacoes.
- [x] Compilacao e rotas principais verificadas.
- [x] Requisitos, diagrama ER, modelo relacional, dicionario de dados e regras de negocio documentados.
- [x] Relatorio de validacao e limites de escopo documentados.
- [ ] Criar suite automatizada de testes.
- [ ] Integrar Tabler, caso seja requisito obrigatorio da avaliacao.
- [ ] Implementar e testar os modulos funcionais nas fases seguintes.
