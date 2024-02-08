using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class LotsViewModel
{
    public Entreprise Entreprise {get;set;}
    public Lot Lot {get;set;}
    public Lot SousLot {get;set;}
    public Lot LotTerminal {get;set;}
    public List<Entreprise> Entreprises { get; set; }
    public List<Lot> Lots { get; set; }
    private readonly BHBqContext _context;

    public LotsViewModel()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        Lots=_context.Lots.ToList();
        Entreprises=_context.Entreprises.ToList();
    }
}