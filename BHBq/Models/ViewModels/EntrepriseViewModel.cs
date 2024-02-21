using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class EntrepriseViewModel
{
    private readonly BHBqContext _context;
    public List<Entreprise> Entreprises;
    public Entreprise TargetEntreprise;
    public List<CompteBancaire> ComptesBancaires;
    public CompteBancaire TargetCompteBancaire;

    public EntrepriseViewModel()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        Entreprises=_context.Entreprises.ToList();
        ComptesBancaires=_context.ComptesBancaires.ToList();
    }
}
