using Microsoft.EntityFrameworkCore;


public class BHBqContext : DbContext
{
    public string DbPath { get; private set; }
    public DbSet<Entreprise> Entreprises { get; set; } = null!; // BHB-Groupe Infos
    public DbSet<Lot> Lots { get; set; } = null!; // BHB-Groupe Infos
    public DbSet<Client> Clients { get; set; } = null!; // Informations clients
    public DbSet<Projet> Projets { get; set; } = null!; // Informations Projets
    public DbSet<Article> Articles { get; set; } = null!; // Informations Articles
    public DbSet<CompteBancaire> ComptesBancaires { get; set; } = null!; // Informations Bancaires des entreprises
    public DbSet<Parametre> Parametres { get; set; } = null!; // Paramètres de modélisation
    public DbSet<TVA> TVAs { get; set; } = null!; // Taux de TVA
    public DbSet<GammeAcompte> GammeAcomptes { get; set; } = null!; // Gammes d'acompte

    // Constructeur pour l'injection de dépendances (production)
    public BHBqContext(DbContextOptions<BHBqContext> options) : base(options) { }
}