using CsvHelper.Configuration.Attributes;

public class TauxTVA
{
    [Ignore] public int Id {get;set;}
    public string CodeTVA { get; set; }
    public decimal Taux { get; set; }

    // Constructeur par défaut
    public TauxTVA()
    {
    }

    // Constructeur paramétré
    public TauxTVA(string codeTVA, decimal taux)
    {
        CodeTVA = codeTVA;
        Taux = taux;
    }
}