# 03 - Modelo Relacional

## Tabelas principais

- Empresas
- Equipamentos
- Tecnicos
- Incidentes
- Vulnerabilidades
- Intervencoes
- RelatoriosSeguranca
- RegistosAtividade

## Chaves primárias

- Empresas.Id
- Equipamentos.Id
- Tecnicos.Id
- Incidentes.Id
- Vulnerabilidades.Id
- Intervencoes.Id
- RelatoriosSeguranca.Id
- RegistosAtividade.Id

## Chaves estrangeiras

- Equipamentos.EmpresaId -> Empresas.Id
- Incidentes.EmpresaId -> Empresas.Id
- Incidentes.EquipamentoId -> Equipamentos.Id
- Incidentes.TecnicoId -> Tecnicos.Id
- Vulnerabilidades.EmpresaId -> Empresas.Id
- Vulnerabilidades.EquipamentoId -> Equipamentos.Id
- Vulnerabilidades.TecnicoId -> Tecnicos.Id
- Intervencoes.TecnicoId -> Tecnicos.Id
- Intervencoes.IncidenteId -> Incidentes.Id
- Intervencoes.VulnerabilidadeId -> Vulnerabilidades.Id
- RelatoriosSeguranca.EmpresaId -> Empresas.Id
- RelatoriosSeguranca.TecnicoId -> Tecnicos.Id
- RegistosAtividade.TecnicoId -> Tecnicos.Id
- RegistosAtividade.EmpresaId -> Empresas.Id

## Índices

- Empresas.NIF único
- Empresas.Email único
- Tecnicos.Email único
- Equipamentos.NumeroSerie único
- Incidentes.Estado
- Incidentes.NivelGravidade
- Incidentes.DataDetecao
- Vulnerabilidades.NivelRisco
- Vulnerabilidades.DataIdentificacao
- RelatoriosSeguranca.DataCriacao
- RegistosAtividade.DataAtividade

## Restrições de integridade

- Foreign keys com eliminação restritiva
- Regras de datas em incidentes, vulnerabilidades e relatórios
- Valores positivos em custo e tempo de trabalho
- Pontuação CVSS entre 0 e 10
- Intervenção com pelo menos uma associação a incidente ou vulnerabilidade
