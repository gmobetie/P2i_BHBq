using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
public class LotsViewModel
{
    public Entreprise Entreprise {get;set;} // Variable qui stocke temporairement l'entreprise sélectionnée
    public Lot Lot {get;set;} // Variable qui stocke temporairement le lot sélectionnée
    public Lot SousLot {get;set;} // Variable qui stocke temporairement le sous-lot sélectionnée
    public Lot LotTerminal {get;set;} // Variable qui stocke temporairement le lot terminal sélectionnée
    public int TargetLotId {get;set;} // Variable qui stocke temporairement l'id du lot sélectionnée;
    public List<Entreprise> Entreprises { get; set; }
    public List<Lot> Lots { get; set; }
    public List<Article> Articles { get; set; }
    public List<Parametre> Parametres { get; set; }
    public List<SelectListItem> ListeParams { get; set; }
    private readonly BHBqContext _context;

    public LotsViewModel()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        Lots=_context.Lots.ToList();
        Entreprises=_context.Entreprises.ToList();
        Articles=_context.Articles.ToList();
        Parametres=_context.Parametres.ToList();
    }
}