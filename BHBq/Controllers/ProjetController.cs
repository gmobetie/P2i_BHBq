using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BHBq.Controllers;

public class ProjetController : Controller
{
    private readonly ILogger<ProjetController> _logger;
    private readonly BHBqContext _context;

    public ProjetController(ILogger<ProjetController> logger)
    {
        _logger = logger;

        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
    }
    public IActionResult ProjetFlow()
    {
        // Récupérer les données de l'entreprise et des clients depuis la base de données
        var entreprises = _context.Entreprises.ToList();
        var listeEntreprises = entreprises
            .Select(
                e =>
                    new SelectListItem
                    {
                        Text = e.NomEntreprise, // Supposons que le nom de l'entreprise est stocké dans une propriété "Name"
                        Value = e.Id.ToString() // Supposons que l'ID de l'entreprise est stocké dans une propriété "Id"
                    }
            )
            .ToList();

        var clients = _context.Clients.ToList();
        var listeClients = clients
            .Select(
                e =>
                    new SelectListItem
                    {
                        Text = e.Nom, // Supposons que le nom de l'entreprise est stocké dans une propriété "Name"
                        Value = e.Id.ToString() // Supposons que l'ID de l'entreprise est stocké dans une propriété "Id"
                    }
            )
            .ToList();

        return View();
    }

    public IActionResult Error(string Message)
    {
        ViewBag.Message = Message;
        ViewBag.Url = HttpContext.Request.Headers["Referer"];
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> NewProjet(Projet projet)
    {
        var client = await _context.Clients.FindAsync(projet.IdClient);
        
        await _context.Projets.AddAsync(projet);
        await _context.SaveChangesAsync();
        return RedirectToAction("ProjetFlow");
    }
}
