﻿using System.ComponentModel.DataAnnotations;
using TastyPoint.API.Profiles.Domain.Models;

namespace TastyPoint.API.Social.Resources;

public class SaveFoodStoreResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(1280)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string Address { get; set; }
    
    [Required]
    public int Rate { get; set; }

    [Required]
    public bool Favorite { get; set; }
    
    [MaxLength(250)]
    public string Image { get; set; }
    
    [Required]
    public int UserProfileId { get; set; }
}