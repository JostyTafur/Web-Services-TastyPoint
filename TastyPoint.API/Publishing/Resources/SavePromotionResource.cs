using System.ComponentModel.DataAnnotations;
using TastyPoint.API.Selling.Domain.Models;

namespace TastyPoint.API.Publishing.Resources;

public class SavePromotionResource
{
    [Required]
    public string? Title { get; set; }
    
    [Required]
    public string? SubTitle { get; set; }
    
    [Required]
    public string? Description { get; set; }
    
    [Required]
    public string? Image { get; set; }
    
    [Required]
    public int? PackId { get; set; }
}