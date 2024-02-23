using CsvHelper.Configuration.Attributes;
public class Article
{
    [Ignore] public int Id { get; set; }
    public string IdLot {get;set;}
    public string Libelle { get; set; }
    public string Unite { get; set; }
    public double PrixH {get;set;}
    public double PrixM {get;set;}
    public double PrixB {get;set;}
    public string Calcul {get;set;} // Stocke le calcul de prix en format Latex

    // Constructeur par défaut
    public Article()
    {
    }

    // Constructeur paramétré
    public Article(string idlot, string libelle, string unite, double prixH, double prixM, double prixB, string calcul)
    {
        IdLot=idlot;
        Libelle = libelle;
        Unite = unite;
        PrixH = prixH;
        PrixM = prixM;
        PrixB = prixB;
        Calcul = calcul;
    }
}