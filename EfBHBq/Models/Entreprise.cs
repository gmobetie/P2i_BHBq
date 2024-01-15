using CsvHelper.Configuration.Attributes;

public class Entreprise // Informations de chaque entreprise BHB-Groupe
{
    [Ignore] public int Id { get; set; }
    public string NomEntreprise { get; set; }
    public string Siret { get; set; }
    public string Statut { get; set; }
    public string Activite { get; set; }
    public string Siege { get; set; }
    public string APE { get; set; }
    public string? Description { get; set; }

    // Constructeur par défaut
    public Entreprise()
    {
    }

    // Constructeur paramétré
    public Entreprise(string nomEntreprise, string siret, string statut, string activite, string siege, string ape, string? description)
    {
        NomEntreprise = nomEntreprise;
        Siret = siret;
        Statut = statut;
        Activite = activite;
        Siege = siege;
        APE = ape;
        Description = description;
    }
}