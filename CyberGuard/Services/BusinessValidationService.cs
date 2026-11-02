using CyberGuard.Models;

namespace CyberGuard.Services;

public static class BusinessValidationService
{
    public static bool ValidarAssociacaoIncidenteEquipamento(Incidente incidente, Equipamento? equipamento)
    {
        if (incidente.EquipamentoId is null)
        {
            return true;
        }

        return equipamento is not null && incidente.EmpresaId == equipamento.EmpresaId;
    }

    public static bool ValidarAssociacaoVulnerabilidadeEquipamento(Vulnerabilidade vulnerabilidade, Equipamento? equipamento)
    {
        if (equipamento is null)
        {
            return false;
        }

        return vulnerabilidade.EmpresaId == equipamento.EmpresaId;
    }

    public static bool ValidarAssociacaoIntervencao(Intervencao intervencao)
    {
        return intervencao.IncidenteId.HasValue || intervencao.VulnerabilidadeId.HasValue;
    }
}
