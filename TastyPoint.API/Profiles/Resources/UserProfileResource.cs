namespace TastyPoint.API.Profiles.Resources;

public class UserProfileResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Type { get; set; }
    
    //Relationships
    //public UserResource User {get; set;}
    //public FoodStoreResource FoodStore {get;set;}
}