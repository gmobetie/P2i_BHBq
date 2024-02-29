using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHBq.Controllers;

public class LotController : Controller
{
    private readonly BHBqContext _context;
    public LotsViewModel Listes { get; set; }

    public LotController()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        Listes = new LotsViewModel();
    }

    //Get toutes les Lots
    public IActionResult Lots(int idEntreprise)
    {
        Listes.Entreprise = _context.Entreprises.Find(idEntreprise);

        return View(Listes);
    }

    [HttpPost]
    public async Task<IActionResult> EditLot(int id, Lot Lot)
    {
        var existingLot = await _context.Lots.FindAsync(id);

        if (existingLot == null)
        {
            return NotFound();
        }

        // Copy the values from the Lot object to the existing object only if the properties are not null
        if (Lot.Designation != null)
        {
            existingLot.Designation = Lot.Designation;
        }
        if (Lot.IdLot != null)
        {
            existingLot.IdLot = Lot.IdLot;
        }
        if (Lot.CoefPose != null)
        {
            existingLot.CoefPose = Lot.CoefPose;
        }
        await _context.SaveChangesAsync();
        return RedirectToAction("Lots", new { idEntreprise = Lot.IdEntreprise });
    }

    [HttpPost]
    public async Task<IActionResult> NewLot(Lot lot)
    {
        // Si le lot existe déjà, retourner une erreur
        var existingLots = await _context.Lots.AnyAsync(l => l.IdLot == lot.IdLot);

        if (existingLots)
        {
            return RedirectToAction(
                "Error",
                "Error",
                new { Message = $"Le lot {lot.IdLot} existe deja !" }
            );
        }
        else
        {
            await _context.Lots.AddAsync(lot);
            await _context.SaveChangesAsync();
            return RedirectToAction("Lots", new { idEntreprise = lot.IdEntreprise });
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteLot(int id)
    {
        var existingLot = await _context.Lots.FindAsync(id);

        if (existingLot == null)
        {
            return NotFound();
        }

        // Supprimer tous les lots commençant par IdLot. de l'entrée
        var lotsToDelete = _context.Lots.Where(l => l.IdLot.StartsWith(existingLot.IdLot));
        var articlesToDelete = _context.Articles.Where(a => lotsToDelete.Any(l => l.Id == a.IdLot));

        _context.Lots.RemoveRange(lotsToDelete);
        _context.Articles.RemoveRange(articlesToDelete);
        await _context.SaveChangesAsync();

        return RedirectToAction("Lots", new { idEntreprise = existingLot.IdEntreprise });
    }

    [HttpPost]
    public async Task<IActionResult> NewArticle(Article article, int IdEntreprise)
    {
        await _context.Articles.AddAsync(article);
        await _context.SaveChangesAsync();
        return RedirectToAction("Lots", new { idEntreprise = IdEntreprise });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteArticle(int id, int IdEntreprise)
    {
        var existingArticle = await _context.Articles.FindAsync(id);

        if (existingArticle == null)
        {
            return NotFound();
        }

        _context.Articles.Remove(existingArticle);
        ;
        await _context.SaveChangesAsync();

        return RedirectToAction("Lots", new { idEntreprise = IdEntreprise });
    }

    [HttpPost]
    public async Task<IActionResult> EditArticle(int id, int IdEntreprise, Article article)
    {
        var existingArticle = await _context.Articles.FindAsync(id);

        if (existingArticle == null)
        {
            return NotFound();
        }

        // Copy the values from the Article object to the existing object only if the properties are not null
        if (article.Libelle != null)
        {
            existingArticle.Libelle = article.Libelle;
        }
        if (article.IdLot != null)
        {
            existingArticle.IdLot = article.IdLot;
        }
        if (article.Unite != null)
        {
            existingArticle.Unite = article.Unite;
        }
        if (article.PrixH != null)
        {
            existingArticle.PrixH = article.PrixH;
        }
        if (article.PrixM != null)
        {
            existingArticle.PrixM = article.PrixM;
        }
        if (article.PrixB != null)
        {
            existingArticle.PrixB = article.PrixB;
        }
        if (article.Calcul != null)
        {
            existingArticle.Calcul = article.Calcul;
        }
        await _context.SaveChangesAsync();
        return RedirectToAction("Lots", new { idEntreprise = IdEntreprise });
    }

}
