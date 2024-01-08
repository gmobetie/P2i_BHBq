public class GammeAcompte
{
    public int Id { get; set; }
    public List<double> Acomptes { get; set; }

    // Constructeur par défaut
    public GammeAcompte()
    {
        Acomptes = new List<double>();
    }

    // Constructeur paramétré
    public GammeAcompte(int id, List<double> acomptes)
    {
        Id = id;
        Acomptes = acomptes ?? new List<double>();
    }
}