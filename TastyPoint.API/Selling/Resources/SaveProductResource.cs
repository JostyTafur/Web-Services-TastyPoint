using System.ComponentModel.DataAnnotations;

namespace TastyPoint.API.Selling.Resources;

public class SaveProductResource
{
    [Required]
    [MaxLength(100)]
    public string name { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string type { get; set; }
    
    [Required]
    public int PackId { get; set; }
}