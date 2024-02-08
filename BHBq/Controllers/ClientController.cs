using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHBq.Controllers;
public class ClientController : Controller
{
    private readonly BHBqContext _context;
    public List<Client> clients { get; set; }

    public ClientController()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        clients = _context.Clients.ToList();
    }

    //Get toutes les clients
    public IActionResult Clients()
    {
        return View(clients);
    }

[HttpPost]
public async Task<IActionResult> EditClient(int id, Client client)
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
    existingClient.Particulier = client.Particulier;

    // Mettre à jour les propriétés spécifiques aux professionnels
    if (client.Particulier == false)
    {
        existingClient.Siret = client.Siret;
        existingClient.TvaIntracom = client.TvaIntracom;
    }

    await _context.SaveChangesAsync();
    return RedirectToAction("Clients");
}

    [HttpPost]
    public async Task<IActionResult> NewClient(Client client)
    {
        var company = new Client
        {
            Nom = client.Nom,
            Adresse = client.Adresse,
            Particulier = client.Particulier,
            Siret = client.TvaIntracom,
        };

        await _context.Clients.AddAsync(company);
        await _context.SaveChangesAsync();
        return RedirectToAction("Clients");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
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