using Microsoft.EntityFrameworkCore;


public class BHBqContext : DbContext
{
    public string DbPath { get; private set; }
    public DbSet<Entreprise> Entreprises { get; set; } = null!; // BHB-Groupe Infos

    // Constructeur pour l'injection de dépendances (production)
    public BHBqContext(DbContextOptions<BHBqContext> options) : base(options) { }
}