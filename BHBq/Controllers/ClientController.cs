using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHBq.Controllers;

public class ClientController : Controller
{
    private readonly BHBqContext _context;
    public ClientViewModel Listes { get; set; }

    public ClientController()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        Listes = new ClientViewModel();
    }

    //Get toutes les clients
    public IActionResult Clients()
    {
        return View(Listes);
    }

    [HttpPost]
    public async Task<IActionResult> EditClient(int id, Client client, int Categorie)
    {
        var existingClient = await _context.Clients.FindAsync(id);

        if (existingClient == null)
        {
            return NotFound();
        }

        // Mettre à jour les propriétés non nulles de l'objet existant
        if (!string.IsNullOrEmpty(client.Nom))
        {
            existingClient.Nom = client.Nom;
        }
        if (!string.IsNullOrEmpty(client.Adresse))
        {
            existingClient.Adresse = client.Adresse;
        }
        if (client.Categorie!=null)
        {
            existingClient.Categorie = Categorie == 1;
            if (client.Categorie == false)
            {
                existingClient.Siret = null;
                existingClient.TvaIntracom = null;
            }
        }

        // Mettre à jour les propriétés spécifiques aux professionnels
        if (client.Categorie == true)
        {
            if (!string.IsNullOrEmpty(client.Siret))
            {
                existingClient.Siret = client.Siret;
            }
            if (!string.IsNullOrEmpty(client.TvaIntracom))
            {
                existingClient.TvaIntracom = client.TvaIntracom;
            }
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Clients");
    }

    [HttpPost]
    public async Task<IActionResult> NewClient(Client client, int Categorie)
    {
        client.Categorie = Categorie == 1;
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
        return RedirectToAction("Clients");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var existingClient = await _context.Clients.FindAsync(id);

        if (existingClient == null)
        {
            return NotFound();
        }

        _context.Clients.Remove(existingClient);
        await _context.SaveChangesAsync();

        return RedirectToAction("Clients");
    }
}
