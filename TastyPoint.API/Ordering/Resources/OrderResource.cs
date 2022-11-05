namespace TastyPoint.API.Ordering.Resources;

public class OrderResource
{
    public int id { get; set; }
    public string restaurant { get; set; }
    public string status { get; set; }
    public string delivery_method { get; set; }
    public float payment_method { get; set; }
}