using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHBq.Controllers;
public class EntrepriseController : Controller
{
    private readonly BHBqContext _context;
    public List<Entreprise> entreprises { get; set; }

    public EntrepriseController()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        entreprises = _context.Entreprises.ToList();
    }

    //Get toutes les entreprises
    public IActionResult Entreprises()
    {
        Entreprise entreprise = new Entreprise();
        return View(entreprises);
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
    existingEntreprise.Description = entreprise.Description;

    await _context.SaveChangesAsync();
    return RedirectToAction("Entreprises");
}

    [HttpPost]
    public async Task<IActionResult> NewEntreprise(Entreprise entreprise)
    {
        var company = new Entreprise
        {
            NomEntreprise = entreprise.NomEntreprise,
            APE = entreprise.APE,
            Siret = entreprise.Siret,
            Description = entreprise.Description,
            Siege = entreprise.Siege,
            Activite = entreprise.Activite,
            Statut = entreprise.Statut
        };
        await _context.Entreprises.AddAsync(company);
        await _context.SaveChangesAsync();
        return RedirectToAction("Entreprises");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
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
