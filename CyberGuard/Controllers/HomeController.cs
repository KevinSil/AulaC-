using System.Diagnostics;
using CyberGuard.Data;
using CyberGuard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CyberGuard.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.TotalEmpresas = await _context.Empresas.CountAsync();
        ViewBag.TotalEquipamentos = await _context.Equipamentos.CountAsync();
        ViewBag.TotalIncidentes = await _context.Incidentes.CountAsync();
        ViewBag.TotalTecnicos = await _context.Tecnicos.CountAsync();

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
