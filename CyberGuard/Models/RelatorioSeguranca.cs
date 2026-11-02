using System.ComponentModel.DataAnnotations;

namespace CyberGuard.Models;

public class RelatorioSeguranca : BaseEntity
{
    [Required]
    public int EmpresaId { get; set; }

    [Required]
    public int TecnicoId { get; set; }

    [Required]
    [StringLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [StringLength(4000)]
    public string? Descricao { get; set; }

    [Required]
    public TipoRelatorio TipoRelatorio { get; set; }

    [Required]
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    [Required]
    public DateTime PeriodoInicio { get; set; }

    public DateTime? PeriodoFim { get; set; }

    [Range(0, int.MaxValue)]
    public int NumeroIncidentes { get; set; }

    [Range(0, int.MaxValue)]
    public int NumeroVulnerabilidades { get; set; }

    [Required]
    public NivelSeguranca NivelSeguranca { get; set; }

    [StringLength(4000)]
    public string? Recomendacoes { get; set; }

    [StringLength(2000)]
    public string? Observacoes { get; set; }

    public Empresa? Empresa { get; set; }
    public Tecnico? Tecnico { get; set; }
}
