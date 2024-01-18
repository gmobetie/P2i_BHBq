public class Article
{
    public int Id { get; set; }
    public int IdLot {get;set;}
    public string Nom { get; set; }
    public string Unite { get; set; }
    public Prix GammePrix {get;set;}

    // Constructeur par défaut
    public Article()
    {
    }

    // Constructeur paramétré
    public Article(int idlot, string nom, string unite, Prix gammeprix)
    {
        IdLot=idlot;
        Nom = nom;
        Unite = unite;
        GammePrix = gammeprix;
    }
}