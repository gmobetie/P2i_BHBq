public class Parametre
{
    public int Id { get; set; }
    public int? IdProjet { get; set; } // Le projet associé au paramètre et null avant attribution
    public string Nom { get; set; }
    public string Valeur { get; set; }

    public Parametre()
    {
        // Constructeur vide
    }

    public Parametre(int id, int? idProjet, string nom, string valeur)
    {
        Id = id;
        IdProjet = idProjet;
        Nom = nom;
        Valeur = valeur;
    }
}