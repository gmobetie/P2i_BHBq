public class Client // Destinataire de la facture
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Adresse { get; set; }
    public bool Particulier { get; set; }
    public string? Siret { get; set; }
    public string? TvaIntracom { get; set; }
    public string SiteConstruction { get; set; }

    // Constructeur par défaut
    public Client()
    {
    }

    // Constructeur paramétré
    public Client(string nom, string adresse, bool particulier, string? siret, string? tvaIntracom, string siteConstruction)
    {
        Nom = nom;
        Adresse = adresse;
        Particulier = particulier;
        Siret = siret;
        TvaIntracom = tvaIntracom;
        SiteConstruction = siteConstruction;
    }
}