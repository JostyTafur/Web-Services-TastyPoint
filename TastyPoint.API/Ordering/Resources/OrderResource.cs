namespace TastyPoint.API.Ordering.Resources;

public class OrderResource
{
    public int Id { get; set; }
    public string Restaurant { get; set; }
    public string Status { get; set; }
    public string DeliveryMethod { get; set; }
    public float PaymentMethod { get; set; }
}