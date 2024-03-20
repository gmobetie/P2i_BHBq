public class Document
{
    public int Id { get; set; }
    public int Type { get; set; }
    public int IdProjet { get; set; }
    public int IdAcompte { get; set; }
    public int IdTVA { get; set; }
    public int IdEntreprise { get; set; }
    public bool Escompte { get; set; }
    public int Origine { get; set; }
    public string Num { get; set; }

    public Document()
    {
        // Empty constructor
    }

    public Document(int type, int idProjet, int idAcompte, int idTVA, int idEntreprise, bool escompte, int origine, string num)
    {
        Type = type;
        IdProjet = idProjet;
        IdAcompte = idAcompte;
        IdTVA = idTVA;
        IdEntreprise = idEntreprise;
        Escompte = escompte;
        Origine = origine;
        Num = num;
    }
}