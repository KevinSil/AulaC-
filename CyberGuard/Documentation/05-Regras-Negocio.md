# 05 - Regras de Negócio

## Regras implementadas na Fase 1

- Cada entidade tem um identificador inteiro.
- As relações têm chaves estrangeiras e eliminacao restritiva.
- NIF e email da empresa, email do tecnico e numero de serie do equipamento sao unicos.
- Incidentes e vulnerabilidades pertencem a uma empresa; vulnerabilidades tambem pertencem a um equipamento.
- A data de resolucao de um incidente nao pode anteceder a data de deteccao.
- A data de correcao de uma vulnerabilidade nao pode anteceder a data de identificacao.
- A pontuacao CVSS, quando indicada, deve estar entre 0 e 10; o Codigo CVE segue o formato validado pelo modelo.
- Intervencoes exigem tecnico, pelo menos uma associacao a incidente ou vulnerabilidade, e custo e tempo nao negativos.
- Relatorios nao aceitam contagens negativas e o periodo final, quando indicado, nao pode anteceder o inicial.
- Campos enumerados sao representados por texto na base de dados SQLite.

## Regras previstas para os modulos funcionais

- Apenas empresas ativas devem surgir em operacoes futuras de relatorio.
- Enderecos IP e MAC devem ser validados quanto ao formato.
- Tecnicos inativos nao devem ser atribuiveis a novas intervencoes.
- Equipamento associado a incidente ou vulnerabilidade deve pertencer a mesma empresa.
- O periodo do relatorio e as associacoes entre entidades devem ser validados tambem na camada de servicos.

Estas regras estao identificadas na analise, mas os fluxos funcionais e respetivas validacoes de servico pertencem as fases seguintes. A Fase 1 nao inclui CRUD nem processos operacionais.
