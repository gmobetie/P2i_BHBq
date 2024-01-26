public class Lot
{
    public int Id { get; set; }
    public string Designation { get; set; }
    public double CoefPose {get;set;}
    public List<Article> Articles { get; set; }

    // Constructeur par défaut
    public Lot()
    {
        Articles = new List<Article>();
    }

    // Constructeur paramétré
    public Lot(string designation, List<Article> articles)
    {
        Designation = designation;
        Articles = articles ?? new List<Article>();
    }
}