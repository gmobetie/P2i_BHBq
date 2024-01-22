using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BHBq.Models;
using Microsoft.EntityFrameworkCore;

namespace BHBq.Controllers;

public class EntrepriseController : Controller
{
    private readonly BHBqContext _context;

    public EntrepriseController()
    {  
        var options = new DbContextOptionsBuilder<BHBqContext>()
        .UseSqlite($"Data Source=BHBq.db")
        .Options;

        _context= new BHBqContext(options);
    }

    //Get toutes les entreprises
    public IActionResult Entreprises()
    {
        List<Entreprise> entreprises = _context.Entreprises.ToList();
        return View(entreprises);
    }

            // PUT: Mettre à jour une entreprise
        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult ModifierEntreprise(int id, Entreprise entreprise)
        {
            if (id != entreprise.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Entry(entreprise).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Entreprises");
            }

            return View(entreprise);
        }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
