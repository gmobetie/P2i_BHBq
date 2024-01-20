using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BHBq.Models;

namespace BHBq.Controllers;

public class EntrepriseController : Controller
{
    private readonly ILogger<EntrepriseController> _logger;

    private readonly BHBqContext _context;

    public EntrepriseController(ILogger<EntrepriseController> logger, BHBqContext context)
    {
        _logger = logger;
        _context= context;
    }

    public IActionResult Entreprises()
    {
        List<Entreprise> entreprises = _context.Entreprises.ToList();
        return View(entreprises);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
