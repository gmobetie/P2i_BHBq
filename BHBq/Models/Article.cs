using CsvHelper.Configuration.Attributes;
public class Article
{
    [Ignore] public int Id { get; set; }
    public int IdLot {get;set;}
    public string Libelle { get; set; }
    public string Unite { get; set; }
    public string PrixH {get;set;}
    public string PrixM {get;set;}
    public string PrixB {get;set;}
    public string? Calcul {get;set;} // Stocke le calcul de prix en format Latex
    public string? FormatCalcul {get;set;} // Stocke le calcul de prix en format texte
    public string? Quantite {get;set;} // Stocke la quantité de l'article

    // Constructeur par défaut
    public Article()
    {
    }

    // Constructeur paramétré
    public Article(int idlot, string libelle, string unite, string prixH, string prixM, string prixB, string? calcul, string? formatCalcul, string? quantite)
    {
        IdLot=idlot;
        Libelle = libelle;
        Unite = unite;
        PrixH = prixH;
        PrixM = prixM;
        PrixB = prixB;
        Calcul = calcul;
        FormatCalcul = formatCalcul;
        Quantite = quantite;
    }
}