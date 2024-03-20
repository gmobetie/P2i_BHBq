using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace BHBq.Controllers;

public class DocumentController : Controller
{
    private readonly BHBqContext _context;
    public ClientViewModel Listes { get; set; }

    public DocumentController()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        Listes = new ClientViewModel();
    }

    //Get tous les documents
    public IActionResult Documents(int idProjet)
    {
        Listes.TargetProjet = _context.Projets.Find(idProjet);
        Listes.TargetClient = _context.Clients.Find(Listes.TargetProjet.IdClient);
        return View(Listes);
    }

    public IActionResult DocumentFlow(int idProjet)
    {
        Listes.TargetProjet = _context.Projets.Find(idProjet);
        Listes.TargetClient = _context.Clients.Find(Listes.TargetProjet.IdClient);

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

        Listes.ListeEntreprises = listeEntreprises;

        return View(Listes);
    }

    [HttpPost]
    public async Task<IActionResult> EditDocument(int id, Document document, int Categorie)
    {
        var existingDocument = await _context.Documents.FindAsync(id);

        if (existingDocument == null)
        {
            return NotFound();
        }

        // Mettre à jour les propriétés non nulles de l'objet existant
        if (document.Type!=null)
        {
            existingDocument.Type = document.Type;
        }
        if (document.IdProjet != 0)
        {
            existingDocument.IdProjet = document.IdProjet;
        }
        if (document.IdAcompte != 0)
        {
            existingDocument.IdAcompte = document.IdAcompte;
        }
        if (document.IdTVA != 0)
        {
            existingDocument.IdTVA = document.IdTVA;
        }
        if (document.IdEntreprise != 0)
        {
            existingDocument.IdEntreprise = document.IdEntreprise;
        }
        if (document.Escompte != null)
        {
            existingDocument.Escompte = document.Escompte;
        }
        if (document.Origine != 0)
        {
            existingDocument.Origine = document.Origine;
        }
        if (!string.IsNullOrEmpty(document.Num))
        {
            existingDocument.Num = document.Num;
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Documents");
    }

    [HttpPost]
    public async Task<IActionResult> NewDocument(Document document, int Categorie)
    {
        await _context.Documents.AddAsync(document);
        await _context.SaveChangesAsync();
        return RedirectToAction("Documents");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteDocument(int id)
    {
        var existingDocument = await _context.Documents.FindAsync(id);

        if (existingDocument == null)
        {
            return NotFound();
        }

        _context.Documents.Remove(existingDocument);
        await _context.SaveChangesAsync();

        return RedirectToAction("Documents");
    }
}
