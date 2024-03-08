using CsvHelper.Configuration.Attributes;

public class Projet
{
    [Ignore] public int Id { get; set; }
    public int IdClient { get; set; }
    public bool Etat { get; set; }
    public string? NomProjet { get; set; }
    public string? DateCreation { get; set; }
    public string? Description { get; set; }
    public bool Init { get; set; }

    public Projet()
    {

    }

    // Constructeur avec paramètres pour initialiser les propriétés
    public Projet(int id, int idClient, bool etat, string? nomProjet, string? dateCreation, string? description, bool init=false)
    {
        Id = id;
        IdClient = idClient;
        Etat = etat;
        NomProjet = nomProjet;
        DateCreation = dateCreation;
        Description = description;
        Init = init;
    }
}