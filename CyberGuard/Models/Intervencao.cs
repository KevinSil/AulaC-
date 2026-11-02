using System.ComponentModel.DataAnnotations;

namespace CyberGuard.Models;

public class Intervencao : BaseEntity
{
    [Required]
    public int TecnicoId { get; set; }

    public int? IncidenteId { get; set; }

    public int? VulnerabilidadeId { get; set; }

    [Required]
    public DateTime DataIntervencao { get; set; } = DateTime.UtcNow;

    [Required]
    public TipoIntervencao TipoIntervencao { get; set; }

    [Required]
    [StringLength(4000)]
    public string DescricaoTrabalho { get; set; } = string.Empty;

    [StringLength(4000)]
    public string? SolucaoAplicada { get; set; }

    [Range(0, double.MaxValue)]
    public decimal TempoTrabalho { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Custo { get; set; }

    [Required]
    public ResultadoIntervencao Resultado { get; set; }

    [StringLength(2000)]
    public string? Observacoes { get; set; }

    public Tecnico? Tecnico { get; set; }
    public Incidente? Incidente { get; set; }
    public Vulnerabilidade? Vulnerabilidade { get; set; }
}
