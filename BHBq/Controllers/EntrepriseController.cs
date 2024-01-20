using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BHBq.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;

namespace BHBq.Controllers;

public class EntrepriseController : Controller
{
    private readonly BHBqContext _context;
    private readonly ILogger<EntrepriseController> _logger;
    public EntrepriseController(BHBqContext context, ILogger<EntrepriseController> logger)
    {
        _context = context;
        _logger = logger;
    }
    public IActionResult Entreprises()
    {
        return View();
    }
    public async Task<ActionResult<IEnumerable<Entreprise>>> GetEntreprises()
    {
        // Get entreprises asynchronously
        var entreprises = await _context.Entreprises.ToListAsync();

        // Return the list of entreprises
        return entreprises;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}