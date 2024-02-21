using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class ProjetViewModel
{
    public int SelectedEntreprise { get; set; } // Variable qui stocke temporairement l'Id l'entreprise sélectionnée
    public int SelectedClient { get; set; }
    public List<SelectListItem> ListeEntreprises { get; set; }
    public List<SelectListItem> ListeClients { get; set; }
    private readonly BHBqContext _context;

    public ProjetViewModel()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
    }
}
