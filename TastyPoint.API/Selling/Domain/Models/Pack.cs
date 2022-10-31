namespace TastyPoint.API.Selling.Domain.Models;

public class Pack
{
    public int id { get; set; }
    public string name { get; set; }
    public float price { get; set; }
    
    //Relationships
    public IList<Product> Products { get; set; } = new List<Product>();
}