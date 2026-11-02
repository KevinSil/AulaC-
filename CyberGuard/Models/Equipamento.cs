using System.ComponentModel.DataAnnotations;

namespace CyberGuard.Models;

public class Equipamento : BaseEntity
{
    [Required]
    public int EmpresaId { get; set; }

    [Required]
    [StringLength(200)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public TipoEquipamento TipoEquipamento { get; set; }

    [StringLength(120)]
    public string? Marca { get; set; }

    [StringLength(120)]
    public string? Modelo { get; set; }

    [StringLength(120)]
    public string? NumeroSerie { get; set; }

    [StringLength(120)]
    public string? SistemaOperativo { get; set; }

    [StringLength(45)]
    public string? EnderecoIP { get; set; }

    [StringLength(45)]
    public string? EnderecoMAC { get; set; }

    public DateTime DataRegisto { get; set; } = DateTime.UtcNow;

    public DateTime? UltimaVerificacao { get; set; }

    public EstadoEquipamento Estado { get; set; } = EstadoEquipamento.Ativo;

    [StringLength(2000)]
    public string? Observacoes { get; set; }

    public Empresa? Empresa { get; set; }
    public ICollection<Incidente> Incidentes { get; set; } = new List<Incidente>();
    public ICollection<Vulnerabilidade> Vulnerabilidades { get; set; } = new List<Vulnerabilidade>();
}
