# 02 - Diagrama Entidade-Relação

```mermaid
erDiagram
    EMPRESA ||--o{ EQUIPAMENTO : possui
    EMPRESA ||--o{ INCIDENTE : tem
    EMPRESA ||--o{ VULNERABILIDADE : tem
    EMPRESA ||--o{ RELATORIO : produz
    EMPRESA ||--o{ REGISTO : regista

    EQUIPAMENTO ||--o{ INCIDENTE : envolve
    EQUIPAMENTO ||--o{ VULNERABILIDADE : apresenta

    TECNICO ||--o{ INCIDENTE : responde
    TECNICO ||--o{ VULNERABILIDADE : avalia
    TECNICO ||--o{ INTERVENCAO : executa
    TECNICO ||--o{ RELATORIO : elabora
    TECNICO ||--o{ REGISTO : gera

    INCIDENTE ||--o{ INTERVENCAO : resolve
    VULNERABILIDADE ||--o{ INTERVENCAO : corrige

    EMPRESA {
        int Id PK
        string Nome
        string NIF
        string Email
        string Telefone
        string Morada
        string CodigoPostal
        string Localidade
        string SetorAtividade
        datetime DataRegisto
        bool Ativa
        string Observacoes
    }

    EQUIPAMENTO {
        int Id PK
        int EmpresaId FK
        string Nome
        string TipoEquipamento
        string Marca
        string Modelo
        string NumeroSerie
        string SistemaOperativo
        string EnderecoIP
        string EnderecoMAC
        datetime DataRegisto
        datetime UltimaVerificacao
        string Estado
        string Observacoes
    }

    TECNICO {
        int Id PK
        string Nome
        string Email
        string Telefone
        string Especialidade
        int NivelExperiencia
        datetime DataAdmissao
        bool Ativo
        string Observacoes
    }

    INCIDENTE {
        int Id PK
        int EmpresaId FK
        int EquipamentoId FK
        int TecnicoId FK
        string Titulo
        string Descricao
        string TipoIncidente
        string NivelGravidade
        string Estado
        datetime DataDetecao
        datetime DataResolucao
        string OrigemDetecao
        string Impacto
        string MedidasAplicadas
        string Observacoes
    }

    VULNERABILIDADE {
        int Id PK
        int EmpresaId FK
        int EquipamentoId FK
        int TecnicoId FK
        string Titulo
        string Descricao
        string CodigoCVE
        string Categoria
        string NivelRisco
        decimal PontuacaoCVSS
        datetime DataIdentificacao
        datetime DataCorrecao
        string Estado
        string Recomendacao
        string Observacoes
    }

    INTERVENCAO {
        int Id PK
        int TecnicoId FK
        int IncidenteId FK
        int VulnerabilidadeId FK
        datetime DataIntervencao
        string TipoIntervencao
        string DescricaoTrabalho
        string SolucaoAplicada
        decimal TempoTrabalho
        decimal Custo
        string Resultado
        string Observacoes
    }

    RELATORIO {
        int Id PK
        int EmpresaId FK
        int TecnicoId FK
        string Titulo
        string Descricao
        string TipoRelatorio
        datetime DataCriacao
        datetime PeriodoInicio
        datetime PeriodoFim
        int NumeroIncidentes
        int NumeroVulnerabilidades
        string NivelSeguranca
        string Recomendacoes
        string Observacoes
    }

    REGISTO {
        int Id PK
        int TecnicoId FK
        int EmpresaId FK
        string TipoAtividade
        string Descricao
        string EntidadeAfetada
        string IdentificadorEntidade
        datetime DataAtividade
        string Observacoes
    }
```

## Cardinalidades

- Empresa 1:N Equipamento
- Empresa 1:N Incidente
- Empresa 1:N Vulnerabilidade
- Empresa 1:N RelatorioSeguranca
- Empresa 1:N RegistoAtividade
- Equipamento 1:N Incidente
- Equipamento 1:N Vulnerabilidade
- Tecnico 1:N Incidente
- Tecnico 1:N Vulnerabilidade
- Tecnico 1:N Intervencao
- Tecnico 1:N RelatorioSeguranca
- Tecnico 1:N RegistoAtividade
- Incidente 1:N Intervencao
- Vulnerabilidade 1:N Intervencao
