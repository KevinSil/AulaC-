using System.ComponentModel.DataAnnotations;

namespace CyberGuard.Models;

public class Vulnerabilidade : BaseEntity
{
    [Required]
    public int EmpresaId { get; set; }

    [Required]
    public int EquipamentoId { get; set; }

    public int? TecnicoId { get; set; }

    [Required]
    [StringLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [StringLength(4000)]
    public string Descricao { get; set; } = string.Empty;

    [RegularExpression(@"^CVE-\d{4}-\d{4,}$")]
    public string? CodigoCVE { get; set; }

    [Required]
    public CategoriaVulnerabilidade Categoria { get; set; }

    [Required]
    public NivelRisco NivelRisco { get; set; }

    [Range(0, 10)]
    public decimal? PontuacaoCVSS { get; set; }

    [Required]
    public DateTime DataIdentificacao { get; set; }

    public DateTime? DataCorrecao { get; set; }

    [Required]
    public EstadoVulnerabilidade Estado { get; set; }

    [StringLength(4000)]
    public string? Recomendacao { get; set; }

    [StringLength(2000)]
    public string? Observacoes { get; set; }

    public Empresa? Empresa { get; set; }
    public Equipamento? Equipamento { get; set; }
    public Tecnico? Tecnico { get; set; }
    public ICollection<Intervencao> Intervencoes { get; set; } = new List<Intervencao>();
}
