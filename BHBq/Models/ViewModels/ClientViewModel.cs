using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class ClientViewModel
{
    public Projet TargetProjet { get; set; }
    public Client TargetClient { get; set; }
    public List<SelectListItem> ListeClients { get; set; }
    public List<Projet> Projets { get; set; }
    public List<Client> Clients { get; set; }
    public List<Parametre> Parametres { get; set; }
    private readonly BHBqContext _context;

    public ClientViewModel()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        Projets=_context.Projets.ToList();
        Clients=_context.Clients.ToList();
        Parametres=_context.Parametres.ToList();
    }
}
