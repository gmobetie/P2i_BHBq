public class CompteBancaire
{
    public int Id { get; set; }
    public int IdEntreprise { get; set; }
    public string Adresse { get; set; }
    public string IBAN { get; set; }
    public string BIC { get; set; }
    public string NumCompte { get; set; }
    public string NomBanque { get; set; }

    public CompteBancaire()
    {
        // Empty constructor
    }

    public CompteBancaire(
        int id,
        int idEntreprise,
        string adresse,
        string iban,
        string bic,
        string numCompte,
        string nomBanque
    )
    {
        Id = id;
        IdEntreprise = idEntreprise;
        Adresse = adresse;
        IBAN = iban;
        BIC = bic;
        NumCompte = numCompte;
        NomBanque = nomBanque;
    }
}
