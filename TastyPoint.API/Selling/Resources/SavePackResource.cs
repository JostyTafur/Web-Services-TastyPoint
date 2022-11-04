using System.ComponentModel.DataAnnotations;
using TastyPoint.API.Selling.Domain.Models;

namespace TastyPoint.API.Selling.Resources;

public class SavePackResource
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    public float Price { get; set; }
    
}