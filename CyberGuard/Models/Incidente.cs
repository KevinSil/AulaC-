using System.ComponentModel.DataAnnotations;

namespace CyberGuard.Models;

public class Incidente : BaseEntity
{
    [Required]
    public int EmpresaId { get; set; }

    public int? EquipamentoId { get; set; }

    public int? TecnicoId { get; set; }

    [Required]
    [StringLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [StringLength(4000)]
    public string Descricao { get; set; } = string.Empty;

    [Required]
    public TipoIncidente TipoIncidente { get; set; }

    [Required]
    public NivelGravidade NivelGravidade { get; set; }

    [Required]
    public EstadoIncidente Estado { get; set; }

    [Required]
    public DateTime DataDetecao { get; set; }

    public DateTime? DataResolucao { get; set; }

    [Required]
    public OrigemDetecao OrigemDetecao { get; set; }

    [StringLength(2000)]
    public string? Impacto { get; set; }

    [StringLength(4000)]
    public string? MedidasAplicadas { get; set; }

    [StringLength(2000)]
    public string? Observacoes { get; set; }

    public Empresa? Empresa { get; set; }
    public Equipamento? Equipamento { get; set; }
    public Tecnico? Tecnico { get; set; }
    public ICollection<Intervencao> Intervencoes { get; set; } = new List<Intervencao>();
}
