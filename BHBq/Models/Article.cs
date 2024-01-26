public class Article
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Unite { get; set; }
    public double PrixH {get;set;}
    public double PrixM {get;set;}
    public double PrixB {get;set;}

    // Constructeur par défaut
    public Article()
    {
    }

    // Constructeur paramétré
    public Article(string nom, string unite, double prixH, double prixM, double prixB)
    {
        Nom = nom;
        Unite = unite;
        PrixB=prixB;
        PrixH=prixH;
        PrixM=prixM;
    }
}