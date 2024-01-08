public class Prix
{
    public int Id { get; set; }
    public int PrixHaut { get; set; }
    public int PrixMoyen { get; set; }
    public int PrixBas { get; set; }

    // Constructeur par défaut
    public Prix()
    {
    }

    // Constructeur paramétré
    public Prix(int prixHaut, int prixMoyen, int prixBas)
    {
        PrixHaut = prixHaut;
        PrixMoyen = prixMoyen;
        PrixBas = prixBas;
    }
}