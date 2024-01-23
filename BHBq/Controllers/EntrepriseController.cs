using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BHBq.Models;
using Microsoft.EntityFrameworkCore;

namespace BHBq.Controllers;

public class EntrepriseController : Controller
{
    private readonly BHBqContext _context;
    public List<Entreprise> entreprises {get;set;}

    public EntrepriseController()
    {  
        var options = new DbContextOptionsBuilder<BHBqContext>()
        .UseSqlite($"Data Source=BHBq.db")
        .Options;

        _context= new BHBqContext(options);
        entreprises = _context.Entreprises.ToList();
    }

    //Get toutes les entreprises
    public IActionResult Entreprises()
    {
        Entreprise entreprise = new Entreprise();
        return View(entreprises);
    }



    [HttpPut]
    [ValidateAntiForgeryToken]
    public IActionResult ModifierEntreprise(int id, [FromBody] Entreprise entreprise)
    {

            // Récupérer l'entreprise existante depuis la base de données
            var entrepriseExistante = _context.Entreprises.Find(id);

            if (entrepriseExistante == null)
            {
                return NotFound(); // Entreprise non trouvée
            }
        if (ModelState.IsValid)
        {
            // Mettre à jour les propriétés de l'entreprise existante avec celles de la nouvelle entreprise
            _context.Entry(entrepriseExistante).CurrentValues.SetValues(entreprise);

            _context.SaveChanges();
            return RedirectToAction("Entreprises");
        }
        else
        {
            return BadRequest("Les informations de mise à jour sont mauvaises !");
        }
    }

    [HttpPost]
    public async Task<IActionResult> NewEntreprise(Entreprise entreprise)
    {
        var company = new Entreprise
        {
            NomEntreprise=entreprise.NomEntreprise,
            APE=entreprise.APE,
            Siret=entreprise.Siret,
            Description=entreprise.Description,
            Siege=entreprise.Siege,
            Activite=entreprise.Activite,
            Statut=entreprise.Statut
        };
        await _context.Entreprises.AddAsync(company);
        await _context.SaveChangesAsync();
        return RedirectToAction("Entreprises");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
