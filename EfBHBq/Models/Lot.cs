using CsvHelper.Configuration.Attributes;

public class Lot
{
    [Ignore] public int Id { get; set; }
    public int? IdSousLot {get;set;}
    public string Designation { get; set; }
    public double? CoefPose {get;set;}

    // Constructeur par défaut
    public Lot()
    {

    }

    // Constructeur paramétré
    public Lot(int? idsouslot, string designation, List<Article> articles)
    {
        Designation = designation;
        IdSousLot=idsouslot;
    }
}