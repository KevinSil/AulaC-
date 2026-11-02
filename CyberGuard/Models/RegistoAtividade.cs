using System.ComponentModel.DataAnnotations;

namespace CyberGuard.Models;

public class RegistoAtividade : BaseEntity
{
    [Required]
    public int TecnicoId { get; set; }

    [Required]
    public int EmpresaId { get; set; }

    [Required]
    public TipoAtividade TipoAtividade { get; set; }

    [Required]
    [StringLength(1000)]
    public string Descricao { get; set; } = string.Empty;

    [StringLength(200)]
    public string? EntidadeAfetada { get; set; }

    [StringLength(200)]
    public string? IdentificadorEntidade { get; set; }

    [Required]
    public DateTime DataAtividade { get; set; } = DateTime.UtcNow;

    [StringLength(2000)]
    public string? Observacoes { get; set; }

    public Tecnico? Tecnico { get; set; }
    public Empresa? Empresa { get; set; }
}
