using System.ComponentModel.DataAnnotations;

namespace CyberGuard.Models;

public class Tecnico : BaseEntity
{
    [Required]
    [StringLength(200)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;

    [Phone]
    [StringLength(30)]
    public string? Telefone { get; set; }

    public EspecialidadeTecnico Especialidade { get; set; }

    [Range(1, 10)]
    public int NivelExperiencia { get; set; }

    public DateTime DataAdmissao { get; set; } = DateTime.UtcNow;

    public bool Ativo { get; set; } = true;

    [StringLength(2000)]
    public string? Observacoes { get; set; }

    public ICollection<Incidente> Incidentes { get; set; } = new List<Incidente>();
    public ICollection<Vulnerabilidade> Vulnerabilidades { get; set; } = new List<Vulnerabilidade>();
    public ICollection<Intervencao> Intervencoes { get; set; } = new List<Intervencao>();
    public ICollection<RelatorioSeguranca> RelatoriosSeguranca { get; set; } = new List<RelatorioSeguranca>();
    public ICollection<RegistoAtividade> RegistosAtividade { get; set; } = new List<RegistoAtividade>();
}
