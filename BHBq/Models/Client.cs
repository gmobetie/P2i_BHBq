using CsvHelper.Configuration.Attributes;
public class Client // Destinataire de la facture, client du groupe
{
    [Ignore] public int Id { get; set; }
    public string Nom { get; set; }
    public string Adresse { get; set; }
    public bool Categorie { get; set; }
    public string? Siret { get; set; } // Uniquement si le client est un professionnel
    public string? TvaIntracom { get; set; } // Uniquement si le client est un professionnel

    // Constructeur par défaut
    public Client()
    {
    }

    // Constructeur paramétré
    public Client(string nom, string adresse, bool categorie, string? siret, string? tvaIntracom)
    {
        Nom = nom;
        Adresse = adresse;
        Categorie = categorie;
        Siret = siret;
        TvaIntracom = tvaIntracom;
    }
}