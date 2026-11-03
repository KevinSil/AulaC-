using CyberGuard.Models;

namespace CyberGuard.ViewModels;

public class EmpresaIndexViewModel
{
    public Empresa Cadastro { get; set; } = new();
    public List<Empresa> Empresas { get; set; } = new();
}
