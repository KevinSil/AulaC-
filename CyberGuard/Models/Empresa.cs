using System.ComponentModel.DataAnnotations;

namespace CyberGuard.Models;

public class Empresa : BaseEntity
{
    [Required]
    [StringLength(200)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [StringLength(9, MinimumLength = 9)]
    [RegularExpression(@"^\d{9}$")]
    public string NIF { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;

    [Phone]
    [StringLength(30)]
    public string? Telefone { get; set; }

    [StringLength(200)]
    public string? Morada { get; set; }

    [StringLength(20)]
    public string? CodigoPostal { get; set; }

    [StringLength(120)]
    public string? Localidade { get; set; }

    [StringLength(120)]
    public string? SetorAtividade { get; set; }

    [Required]
    public DateTime DataRegisto { get; set; } = DateTime.UtcNow;

    public bool Ativa { get; set; } = true;

    [StringLength(2000)]
    public string? Observacoes { get; set; }

    public ICollection<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();
    public ICollection<Incidente> Incidentes { get; set; } = new List<Incidente>();
    public ICollection<Vulnerabilidade> Vulnerabilidades { get; set; } = new List<Vulnerabilidade>();
    public ICollection<RelatorioSeguranca> RelatoriosSeguranca { get; set; } = new List<RelatorioSeguranca>();
    public ICollection<RegistoAtividade> RegistosAtividade { get; set; } = new List<RegistoAtividade>();
}
