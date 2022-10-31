namespace TastyPoint.API.Selling.Domain.Models;

public class Product
{
    public int id { get; set; }
    public string name { get; set; }
    public string type { get; set; }

    //Relationships
    public int PackId { get; set; }
    public Pack Pack { get; set; }
}