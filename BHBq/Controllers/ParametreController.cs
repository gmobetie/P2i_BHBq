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
}
