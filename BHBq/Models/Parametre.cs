public class Parametre
{
    public int Id { get; set; }
    public int? IdProjet { get; set; } // Le projet associé au paramètre et null avant attribution
    public string Nom { get; set; }
    public string? Valeur { get; set; }
    public string? Explication { get; set; }

    public Parametre()
    {
        // Constructeur vide
    }

    public Parametre(int id, string nom, int? idProjet, string? valeur, string? explication)
    {
        Id = id;
        Nom = nom;
        IdProjet = idProjet;
        Valeur = valeur;
        Explication = explication;
    }
}