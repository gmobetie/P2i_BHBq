public class TVA
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Taux { get; set; }

    public TVA()
    {
        // Constructeur vide
    }

    public TVA(int id, string? code, string? taux)
    {
        Id = id;
        Code = code;
        Taux = taux;
    }
}