public class GammeAcompte
{
    public string? Id { get; set; }
    public string? Pourcentage1 { get; set; }
    public string? Pourcentage2 { get; set; }
    public string? Pourcentage3 { get; set; }
    public string? Pourcentage4 { get; set; }
    public string? Pourcentage5 { get; set; }

    public GammeAcompte()
    {
        // Constructeur vide
    }

    public GammeAcompte(string? id, string? pourcentage1, string? pourcentage2, string? pourcentage3, string? pourcentage4, string? pourcentage5)
    {
        Id = id;
        Pourcentage1 = pourcentage1;
        Pourcentage2 = pourcentage2;
        Pourcentage3 = pourcentage3;
        Pourcentage4 = pourcentage4;
        Pourcentage5 = pourcentage5;
    }
}