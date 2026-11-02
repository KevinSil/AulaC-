# 04 - Dicionário de Dados

## Empresa

- Id: int, obrigatório, PK
- Nome: string, obrigatório
- NIF: string, obrigatório, único
- Email: string, obrigatório, único
- Telefone: string, opcional
- Morada: string, opcional
- CodigoPostal: string, opcional
- Localidade: string, opcional
- SetorAtividade: string, opcional
- DataRegisto: DateTime, obrigatório
- Ativa: bool, obrigatório
- Observacoes: string, opcional

## Equipamento

- Id: int, obrigatório, PK
- EmpresaId: int, obrigatório, FK
- Nome: string, obrigatório
- TipoEquipamento: enum, obrigatório
- Marca: string, opcional
- Modelo: string, opcional
- NumeroSerie: string, opcional, único
- SistemaOperativo: string, opcional
- EnderecoIP: string, opcional
- EnderecoMAC: string, opcional
- DataRegisto: DateTime, obrigatório
- UltimaVerificacao: DateTime, opcional
- Estado: enum, obrigatório
- Observacoes: string, opcional

## Tecnico

- Id: int, obrigatório, PK
- Nome: string, obrigatório
- Email: string, obrigatório, único
- Telefone: string, opcional
- Especialidade: enum, obrigatório
- NivelExperiencia: int, obrigatório
- DataAdmissao: DateTime, obrigatório
- Ativo: bool, obrigatório
- Observacoes: string, opcional

## Incidente

- Id: int, obrigatório, PK
- EmpresaId: int, obrigatório, FK
- EquipamentoId: int, opcional, FK
- TecnicoId: int, opcional, FK
- Titulo: string, obrigatório
- Descricao: string, obrigatório
- TipoIncidente: enum, obrigatório
- NivelGravidade: enum, obrigatório
- Estado: enum, obrigatório
- DataDetecao: DateTime, obrigatório
- DataResolucao: DateTime, opcional
- OrigemDetecao: enum, obrigatório
- Impacto: string, opcional
- MedidasAplicadas: string, opcional
- Observacoes: string, opcional

## Vulnerabilidade

- Id: int, obrigatório, PK
- EmpresaId: int, obrigatório, FK
- EquipamentoId: int, obrigatório, FK
- TecnicoId: int, opcional, FK
- Titulo: string, obrigatório
- Descricao: string, obrigatório
- CodigoCVE: string, opcional
- Categoria: enum, obrigatório
- NivelRisco: enum, obrigatório
- PontuacaoCVSS: decimal, opcional
- DataIdentificacao: DateTime, obrigatório
- DataCorrecao: DateTime, opcional
- Estado: enum, obrigatório
- Recomendacao: string, opcional
- Observacoes: string, opcional

## Intervencao

- Id: int, obrigatório, PK
- TecnicoId: int, obrigatório, FK
- IncidenteId: int, opcional, FK
- VulnerabilidadeId: int, opcional, FK
- DataIntervencao: DateTime, obrigatório
- TipoIntervencao: enum, obrigatório
- DescricaoTrabalho: string, obrigatório
- SolucaoAplicada: string, opcional
- TempoTrabalho: decimal, obrigatório
- Custo: decimal, obrigatório
- Resultado: enum, obrigatório
- Observacoes: string, opcional

## RelatorioSeguranca

- Id: int, obrigatório, PK
- EmpresaId: int, obrigatório, FK
- TecnicoId: int, obrigatório, FK
- Titulo: string, obrigatório
- Descricao: string, opcional
- TipoRelatorio: enum, obrigatório
- DataCriacao: DateTime, obrigatório
- PeriodoInicio: DateTime, obrigatório
- PeriodoFim: DateTime, opcional
- NumeroIncidentes: int, obrigatório
- NumeroVulnerabilidades: int, obrigatório
- NivelSeguranca: enum, obrigatório
- Recomendacoes: string, opcional
- Observacoes: string, opcional

## RegistoAtividade

- Id: int, obrigatório, PK
- TecnicoId: int, obrigatório, FK
- EmpresaId: int, obrigatório, FK
- TipoAtividade: enum, obrigatório
- Descricao: string, obrigatório
- EntidadeAfetada: string, opcional
- IdentificadorEntidade: string, opcional
- DataAtividade: DateTime, obrigatório
- Observacoes: string, opcional
