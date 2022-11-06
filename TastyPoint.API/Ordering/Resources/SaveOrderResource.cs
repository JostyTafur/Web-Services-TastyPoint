using System.ComponentModel.DataAnnotations;

namespace TastyPoint.API.Ordering.Resources;

public class SaveOrderResource
{
    [Required]
    public string DeliveryMethod { get; set; }
    
    [Required]
    public float PaymentMethod { get; set; }
    
    [Required]
    public float Status { get; set; }
    
    [Required]
    public float Restaurant { get; set; }
}