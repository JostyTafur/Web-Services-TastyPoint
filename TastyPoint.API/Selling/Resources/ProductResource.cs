namespace TastyPoint.API.Selling.Resources;

public class ProductResource
{
    public int Id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public PackResource Pack { get; set; }
}