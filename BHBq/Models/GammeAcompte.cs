class GammeAcompte
{
    public int Id { get; set; }
    public double Pourcentage1 { get; set; }
    public double Pourcentage2 { get; set; }
    public double Pourcentage3 { get; set; }
    public double Pourcentage4 { get; set; }
    public double Pourcentage5 { get; set; }

    public GammeAcompte()
    {
        // Constructeur vide
    }

    public GammeAcompte(int id, double pourcentage1, double pourcentage2, double pourcentage3, double pourcentage4, double pourcentage5)
    {
        Id = id;
        Pourcentage1 = pourcentage1;
        Pourcentage2 = pourcentage2;
        Pourcentage3 = pourcentage3;
        Pourcentage4 = pourcentage4;
        Pourcentage5 = pourcentage5;
    }
}