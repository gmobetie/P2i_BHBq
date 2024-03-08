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
    public ClientViewModel Listes { get; set; }

    public ProjetController(ILogger<ProjetController> logger)
    {
        _logger = logger;

        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        Listes = new ClientViewModel();
    }

    //Get toutes les Projets
    public IActionResult Projets(int idClient)
    {
        Listes.TargetClient = _context.Clients.Find(idClient);

        return View(Listes);
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
        await _context.Projets.AddAsync(projet);
        await _context.SaveChangesAsync();
        return RedirectToAction("Projets", new { idClient = projet.IdClient });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProjet(int id)
    {
        var existingProjet = await _context.Projets.FindAsync(id);

        if (existingProjet == null)
        {
            return NotFound();
        }

        _context.Projets.Remove(existingProjet);
        await _context.SaveChangesAsync();

        return RedirectToAction("Projets", new { idClient = existingProjet.IdClient });
    }

    [HttpPost]
    public async Task<IActionResult> EditProjet(int id, Projet projet)
    {
        var existingProjet = await _context.Projets.FindAsync(id);

        if (existingProjet == null)
        {
            return NotFound();
        }

        // Copy the values from the projet object to the existing object only if the properties are not null
        if (projet.NomProjet != null)
        {
            existingProjet.NomProjet = projet.NomProjet;
        }
        if (projet.Etat != null)
        {
            existingProjet.Etat = projet.Etat;
        }
        if (projet.DateCreation != null)
        {
            existingProjet.DateCreation = projet.DateCreation;
        }
        if (projet.Description != null)
        {
            existingProjet.Description = projet.Description;
        }
        await _context.SaveChangesAsync();
        return RedirectToAction("Projets", new { idClient = existingProjet.IdClient });
    }

    public async Task<IActionResult> UpdateParams(int idProjet, List<Parametre> parametres)
    {
        var existingProjet = await _context.Projets.FindAsync(idProjet);
        foreach (var param in parametres)
        {
            var existingParam = await _context.Parametres.FindAsync(param.Id);
            if (existingParam != null)
            {
                existingParam.Valeur = param.Valeur;
            }
        }
        await _context.SaveChangesAsync();
        return RedirectToAction("Projets", new { idClient = existingProjet.IdClient });
    }

    public async Task<IActionResult> CloneParams(int idProjet)
    {
        var existingProjet = await _context.Projets.FindAsync(idProjet);
        var originParams = await _context.Parametres.Where(p => p.Origine == null).ToListAsync();

        if (existingProjet != null)
        {
            foreach (var param in originParams)
            {
                var clonedParameter = new Parametre
                {
                    Nom = param.Nom,
                    Origine = param.Id,
                    IdProjet = existingProjet.Id
                };
                _context.Parametres.Add(clonedParameter);
            }
            existingProjet.Init = true;
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("ProjetParametre", new { idProjet = existingProjet.Id });
    }

    public IActionResult ProjetParametre(int idProjet)
    {
        Listes.TargetProjet = _context.Projets.Find(idProjet);
        Listes.TargetClient = _context.Clients.Find(Listes.TargetProjet.IdClient);
/* 
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
            .ToList(); */

        return View(Listes);
    }
    public async Task<IActionResult> ResetParams(int idProjet)
    {
        var existingProjet = await _context.Projets.FindAsync(idProjet);
        var projectParams = await _context.Parametres.Where(p => p.IdProjet == idProjet).ToListAsync();

        if (existingProjet != null)
        {
            _context.Parametres.RemoveRange(projectParams);
            existingProjet.Init = false;
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Projets", new { idClient = existingProjet.IdClient });
    }

}
