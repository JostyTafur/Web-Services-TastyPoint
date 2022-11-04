namespace TastyPoint.API.Selling.Domain.Models;

public class Pack
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    
    //Relationships
    public IList<Product> Products { get; set; } = new List<Product>();
}