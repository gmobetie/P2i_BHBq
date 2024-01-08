public class TauxTVA
{
    public string CodeTVA { get; set; }
    public double Taux { get; set; }

    // Constructeur par défaut
    public TauxTVA()
    {
    }

    // Constructeur paramétré
    public TauxTVA(string codeTVA, double taux)
    {
        CodeTVA = codeTVA;
        Taux = taux;
    }
}