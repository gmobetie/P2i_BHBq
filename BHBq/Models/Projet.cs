using CsvHelper.Configuration.Attributes;

public class Projet
{
    [Ignore] public int Id { get; set; }
    public int IdEntreprise { get; set; }
    public int IdClient { get; set; }

    public Projet()
    {

    }

    // Constructeur avec paramètres pour initialiser les propriétés
    public Projet(int id, int idEntreprise, int idClient)
    {
        Id = id;
        IdEntreprise=idEntreprise;
        IdClient=IdClient;
    }
}