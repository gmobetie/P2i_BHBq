using CsvHelper.Configuration.Attributes;
public class Article
{
    [Ignore] public int Id { get; set; }
    public int IdLot {get;set;}
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
    public Article(int idlot, string nom, string unite, double prixH, double prixM, double prixB)
    {
        IdLot=idlot;
        Nom = nom;
        Unite = unite;
        PrixH = prixH;
        PrixM = prixM;
        PrixB = prixB;
    }
}