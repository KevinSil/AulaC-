# 01 - Requisitos

## Objetivo da aplicação

A aplicação CyberGuard visa centralizar a gestão de cibersegurança nas organizações, permitindo acompanhar ativos, incidentes, vulnerabilidades, intervenções e relatórios.

## Descrição do sistema

A plataforma reúne toda a informação relevante para a segurança informática de uma organização, organizando o tratamento de incidentes e vulnerabilidades e preparando a base para futuras capacidades de monitorização.

## Requisitos funcionais

- Gestão de empresas.
- Gestão de equipamentos informáticos.
- Gestão de técnicos de segurança.
- Registo de incidentes.
- Registo de vulnerabilidades.
- Registo de intervenções técnicas.
- Produção de relatórios de segurança.
- Histórico de atividades.

## Requisitos não funcionais

- Persistência em SQLite.
- Arquitetura preparada para extensões futuras.
- Validação de integridade e consistência.
- Estrutura MVC com Entity Framework Core.

## Requisitos técnicos

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQLite
- Bootstrap 5 / Tabler

## Regras de negócio

- Empresa com NIF e email únicos.
- Equipamento associado a uma empresa.
- Incidente associado à empresa e, opcionalmente, a um equipamento.
- Vulnerabilidade associada a empresa e equipamento.
- Intervenção exige técnico responsável.
- Intervenção deve estar associada a incidente ou vulnerabilidade.

## Limitações da primeira fase

- Não existem controllers CRUD funcionais.
- Não há autenticação, dashboard ou monitorização em tempo real.
- A lógica de negócio avançada fica preparada para a camada de serviços na Fase 2.
