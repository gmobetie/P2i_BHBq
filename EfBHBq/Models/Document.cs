public class Document
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public int IdClient { get; set; }
    public int IdEntreprise { get; set; }
    public string Type { get; set; }

    // Constructeur par défaut
    public Document()
    {
    }

    // Constructeur paramétré
    public Document(int id, string numero, int idClient, int idEntreprise, string type)
    {
        Id = id;
        Numero = numero;
        IdClient = idClient;
        IdEntreprise = idEntreprise;
        Type = type;
    }
}