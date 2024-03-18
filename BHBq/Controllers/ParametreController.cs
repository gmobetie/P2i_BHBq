using System.Diagnostics;
using BHBq.Models;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHBq.Controllers;

public class ParametreController : Controller
{
    private readonly BHBqContext _context;
    public ParametreViewModel DataLink { get; set; }

    public ParametreController()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        DataLink = new ParametreViewModel();
    }

    //Get tous les parametres
    public IActionResult Parametres()
    {
        return View(DataLink);
    }

    //Display des parametres généraux
    public async Task<IActionResult> Global()
    {
        return View(DataLink);
    }

    [HttpPost]
    public async Task<IActionResult> EditParametre(int id, Parametre parametre)
    {
        var existingParametre = await _context.Parametres.FindAsync(id);

        if (existingParametre == null)
        {
            return NotFound();
        }

        // Mettre à jour les propriétés non nulles de l'objet existant
        if (!string.IsNullOrEmpty(parametre.Nom))
        {
            existingParametre.Nom = parametre.Nom;
        }
        if (!string.IsNullOrEmpty(parametre.Valeur))
        {
            existingParametre.Valeur = parametre.Valeur;
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Parametres");
    }

    [HttpPost]
    public async Task<IActionResult> NewParametre(Parametre parametre)
    {
        await _context.Parametres.AddAsync(parametre);
        await _context.SaveChangesAsync();
        return RedirectToAction("Parametres");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteParametre(int id)
    {
        var existingParametre = await _context.Parametres.FindAsync(id);

        if (existingParametre == null)
        {
            return NotFound();
        }

        _context.Parametres.Remove(existingParametre);
        await _context.SaveChangesAsync();

        return RedirectToAction("Parametres");
    }

    [HttpPost]
    public async Task<IActionResult> EditTVA(int id, TVA tva)
    {
        var existingTVA = await _context.TVAs.FindAsync(id);

        if (existingTVA == null)
        {
            return NotFound();
        }

        // Mettre à jour les propriétés non nulles de l'objet existant
        if (!string.IsNullOrEmpty(tva.Code))
        {
            existingTVA.Code = tva.Code;
        }
        if (!string.IsNullOrEmpty(tva.Taux))
        {
            existingTVA.Taux = tva.Taux;
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Global");
    }

    [HttpPost]
    public async Task<IActionResult> NewTVA(TVA tva)
    {
        await _context.TVAs.AddAsync(tva);
        await _context.SaveChangesAsync();
        return RedirectToAction("Global");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteTVA(int id)
    {
        var existingTVA = await _context.TVAs.FindAsync(id);

        if (existingTVA == null)
        {
            return NotFound();
        }

        _context.TVAs.Remove(existingTVA);
        await _context.SaveChangesAsync();

        return RedirectToAction("Global");
    }

    public async Task<IActionResult> EditAcompte(string id, GammeAcompte gammeAcompte)
    {
        var existingGammeAcompte = await _context.GammeAcomptes.FindAsync(id);

        if (existingGammeAcompte == null)
        {
            return NotFound();
        }

        // Mettre à jour les propriétés non nulles de l'objet existant
        if (!string.IsNullOrEmpty(gammeAcompte.Pourcentage1))
        {
            existingGammeAcompte.Pourcentage1 = gammeAcompte.Pourcentage1;
        }
        if (!string.IsNullOrEmpty(gammeAcompte.Pourcentage2))
        {
            existingGammeAcompte.Pourcentage2 = gammeAcompte.Pourcentage2;
        }
        if (!string.IsNullOrEmpty(gammeAcompte.Pourcentage3))
        {
            existingGammeAcompte.Pourcentage3 = gammeAcompte.Pourcentage3;
        }
        if (!string.IsNullOrEmpty(gammeAcompte.Pourcentage4))
        {
            existingGammeAcompte.Pourcentage4 = gammeAcompte.Pourcentage4;
        }
        if (!string.IsNullOrEmpty(gammeAcompte.Pourcentage5))
        {
            existingGammeAcompte.Pourcentage5 = gammeAcompte.Pourcentage5;
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Global");
    }

    [HttpPost]
    public async Task<IActionResult> NewAcompte(GammeAcompte gammeAcompte)
    {
        await _context.GammeAcomptes.AddAsync(gammeAcompte);
        await _context.SaveChangesAsync();
        return RedirectToAction("Global");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAcompte(string id)
    {
        var existingGammeAcompte = await _context.GammeAcomptes.FindAsync(id);

        if (existingGammeAcompte == null)
        {
            return NotFound();
        }

        _context.GammeAcomptes.Remove(existingGammeAcompte);
        await _context.SaveChangesAsync();

        return RedirectToAction("Global");
    }
}
