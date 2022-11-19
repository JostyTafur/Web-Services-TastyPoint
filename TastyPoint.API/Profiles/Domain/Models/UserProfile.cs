using TastyPoint.API.Ordering.Domain.Models;
using TastyPoint.API.Security.Domain.Models;
using TastyPoint.API.Social.Domain.Models;

namespace TastyPoint.API.Profiles.Domain.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Type { get; set; }
    
    //Relationships
    public int UserId {get; set;}
    public User User { get; set; }

    public IList<Order> Orders { get; set; } = new List<Order>();
    
    public FoodStore FoodStore { get; set; }
}