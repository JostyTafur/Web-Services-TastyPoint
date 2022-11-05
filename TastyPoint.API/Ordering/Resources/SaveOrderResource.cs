using System.ComponentModel.DataAnnotations;

namespace TastyPoint.API.Ordering.Resources;

public class SaveOrderResource
{
    [Required]
    public string Delivery_method { get; set; }
    
    [Required]
    public float Payment_method { get; set; }
    
    [Required]
    public float Status { get; set; }
    
    [Required]
    public float Restaurant { get; set; }
}