﻿namespace TastyPoint.API.Profiles.Domain.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Type { get; set; }
    
    //Relationships
    //public int  FoodStoreId {get; set;}
}