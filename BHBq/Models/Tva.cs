class TVA
{
    public int Id { get; set; }
    public string Code { get; set; }
    public double Taux { get; set; }

    public TVA()
    {
        // Constructeur vide
    }

    public TVA(int id, string code, double taux)
    {
        Id = id;
        Code = code;
        Taux = taux;
    }
}