using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class ParametreViewModel
{
    private readonly BHBqContext _context;
    public Parametre TargetParametre{get; set;}
    public List<Parametre> Parametres{get; set;}
    public List<TVA> TVAs{get; set;}
    public List<GammeAcompte> GammeAcomptes{get; set;}

    public ParametreViewModel()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        Parametres=_context.Parametres.ToList();
        TVAs=_context.TVAs.ToList();
        GammeAcomptes=_context.GammeAcomptes.ToList();
    }
}