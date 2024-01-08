public class Article
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Unite { get; set; }
    public Prix GammePrix {get;set;}

    // Constructeur par défaut
    public Article()
    {
    }

    // Constructeur paramétré
    public Article(string nom, string unite, Prix gammeprix)
    {
        Nom = nom;
        Unite = unite;
        GammePrix = gammeprix;
    }
}