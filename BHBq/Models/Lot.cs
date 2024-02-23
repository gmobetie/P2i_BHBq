using CsvHelper.Configuration.Attributes;

public class Lot
{
    [Ignore] public int Id { get; set; }
    public string IdLot { get; set; }
    public int? IdEntreprise { get; set; }
    public string Designation { get; set; }
    public string? CoefPose { get; set; }

    public Lot()
    {

    }

    // Constructeur avec paramètres pour initialiser les propriétés
    public Lot(int id, string idLot, int? idEntreprise, string designation, string? coefPose)
    {
        Id = id;
        IdLot = idLot;
        IdEntreprise = idEntreprise;
        Designation = designation;
        CoefPose = coefPose;
    }
}