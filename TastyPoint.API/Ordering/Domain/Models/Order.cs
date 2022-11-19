using TastyPoint.API.Security.Domain.Models;

namespace TastyPoint.API.Ordering.Domain.Models;

public class Order
{
    public int Id { get; set; }
    
    public string Restaurant { get; set; }
    public string Status { get; set; }
    
    public string DeliveryMethod { get; set; }
    public string PaymentMethod { get; set; }
    
    //Relationships
    public int UserId { get; set; }
    public User User { get; set; }
}