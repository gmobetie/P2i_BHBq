using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHBq.Controllers;

public class EntrepriseController : Controller
{
    private readonly BHBqContext _context;
    public List<Entreprise> entreprises { get; set; }
    public EntrepriseViewModel Listes { get; set; }

    public EntrepriseController()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        Listes = new EntrepriseViewModel();
    }

    //Get toutes les entreprises
    public IActionResult Entreprises()
    {
        return View(Listes);
    }

    [HttpPost]
    public async Task<IActionResult> EditEntreprise(int id, Entreprise entreprise)
    {
        var existingEntreprise = await _context.Entreprises.FindAsync(id);

        if (existingEntreprise == null)
        {
            return NotFound();
        }

        // Mettre à jour les propriétés non nulles de l'objet existant
        if (!string.IsNullOrEmpty(entreprise.NomEntreprise))
        {
            existingEntreprise.NomEntreprise = entreprise.NomEntreprise;
        }
        if (!string.IsNullOrEmpty(entreprise.Siret))
        {
            existingEntreprise.Siret = entreprise.Siret;
        }
        if (!string.IsNullOrEmpty(entreprise.Statut))
        {
            existingEntreprise.Statut = entreprise.Statut;
        }
        if (!string.IsNullOrEmpty(entreprise.Activite))
        {
            existingEntreprise.Activite = entreprise.Activite;
        }
        if (!string.IsNullOrEmpty(entreprise.Siege))
        {
            existingEntreprise.Siege = entreprise.Siege;
        }
        if (!string.IsNullOrEmpty(entreprise.APE))
        {
            existingEntreprise.APE = entreprise.APE;
        }
                if (!string.IsNullOrEmpty(entreprise.APE))
        {
            existingEntreprise.APE = entreprise.APE;
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Entreprises");
    }

    [HttpPost]
    public async Task<IActionResult> NewEntreprise(Entreprise entreprise)
    {
        if (!long.TryParse(entreprise.Siret, out _))
        {
            return RedirectToAction(
                "Error",
                "Error",
                new { Message = "Le siret doit être un nombre entier !" }
            );
        }
        else if (
            // Vérifie si les quatre premiers caractères sont des chiffres
            // Vérifie si le cinquième caractère est une lettre
            !char.IsDigit(entreprise.APE[0])
            || !char.IsDigit(entreprise.APE[1])
            || !char.IsDigit(entreprise.APE[2])
            || !char.IsDigit(entreprise.APE[3])
            || !char.IsLetter(entreprise.APE[4])
        )
        {
            return RedirectToAction(
                "Error",
                "Error",
                new { Message = "Le code APE rentré n'est pas au bon format !" }
            );
        }
        else
        {
            await _context.Entreprises.AddAsync(entreprise);
            await _context.SaveChangesAsync();
            return RedirectToAction("Entreprises");
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteEntreprise(int id)
    {
        var existingEntreprise = await _context.Entreprises.FindAsync(id);

        if (existingEntreprise == null)
        {
            return NotFound();
        }

        _context.Entreprises.Remove(existingEntreprise);
        await _context.SaveChangesAsync();

        return RedirectToAction("Entreprises");
    }
}
