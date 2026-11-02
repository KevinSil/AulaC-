namespace CyberGuard.Models;

public enum TipoEquipamento
{
    Computador,
    Portatil,
    Servidor,
    Router,
    Switch,
    Firewall,
    Impressora,
    Outro
}

public enum EstadoEquipamento
{
    Ativo,
    Inativo,
    EmManutencao,
    Desativado
}

public enum EspecialidadeTecnico
{
    SegurancaDeRedes,
    SegurancaDeSistemas,
    AnaliseDeMalware,
    GestaoDeVulnerabilidades,
    RespostaAIncidentes,
    AuditoriaDeSeguranca,
    Outra
}

public enum TipoIncidente
{
    Malware,
    Ransomware,
    Phishing,
    AcessoNaoAutorizado,
    TentativaDeIntrusao,
    FugaDeInformacao,
    AtaqueDeNegacaoDeServico,
    ConfiguracaoIncorreta,
    Outro
}

public enum NivelGravidade
{
    Baixa,
    Media,
    Alta,
    Critica
}

public enum EstadoIncidente
{
    Detetado,
    EmAnalise,
    EmResolucao,
    Resolvido,
    Encerrado
}

public enum OrigemDetecao
{
    Monitorizacao,
    Auditoria,
    ComunicacaoDoUtilizador,
    AnaliseTecnica,
    Outra
}

public enum CategoriaVulnerabilidade
{
    SoftwareDesatualizado,
    FalhaDeSeguranca,
    ConfiguracaoInsegura,
    CredenciaisFracas,
    PortaExposta,
    FalhaDeAutenticacao,
    Outra
}

public enum NivelRisco
{
    Baixo,
    Medio,
    Alto,
    Critico
}

public enum EstadoVulnerabilidade
{
    Identificada,
    EmAnalise,
    EmCorrecao,
    Corrigida,
    AceiteComoRisco
}

public enum TipoIntervencao
{
    AnaliseDeSeguranca,
    RemocaoDeMalware,
    CorrecaoDeVulnerabilidade,
    AtualizacaoDeSoftware,
    ReconfiguracaoDeSistemas,
    RecuperacaoDeDados,
    ReforcoDeSeguranca,
    Auditoria,
    Outro
}

public enum ResultadoIntervencao
{
    Resolvido,
    ParcialmenteResolvido,
    NaoResolvido,
    NecessitaAcompanhamento
}

public enum TipoRelatorio
{
    AuditoriaDeSeguranca,
    AvaliacaoDeVulnerabilidades,
    RelatorioDeIncidentes,
    AvaliacaoGeralDeSeguranca,
    RelatorioPeriodico,
    Outro
}

public enum NivelSeguranca
{
    Critico,
    Baixo,
    Moderado,
    Bom,
    Excelente
}

public enum TipoAtividade
{
    Criacao,
    Atualizacao,
    Eliminacao,
    Resolucao,
    Correcao,
    Auditoria,
    Outro
}
