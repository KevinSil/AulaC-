using CyberGuard.Data;
using CyberGuard.Models;
using CyberGuard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CyberGuard.Controllers;

public class EmpresaController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmpresaController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var model = new EmpresaIndexViewModel
        {
            Empresas = await _context.Empresas
                .OrderBy(e => e.Nome)
                .ToListAsync()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmpresaIndexViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Empresas = await _context.Empresas
                .OrderBy(e => e.Nome)
                .ToListAsync();

            return View("Index", model);
        }

        model.Cadastro.DataRegisto = model.Cadastro.DataRegisto == default
            ? DateTime.UtcNow
            : model.Cadastro.DataRegisto;

        _context.Empresas.Add(model.Cadastro);
        await _context.SaveChangesAsync();

        TempData["MensagemSucesso"] = $"Empresa '{model.Cadastro.Nome}' criada com sucesso.";
        return RedirectToAction(nameof(Index));
    }
}
