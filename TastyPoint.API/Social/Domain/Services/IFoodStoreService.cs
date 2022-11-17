using TastyPoint.API.Social.Domain.Models;
using TastyPoint.API.Social.Domain.Services.Communication;

namespace TastyPoint.API.Social.Domain.Services;

public interface IFoodStoreService
{
    Task<IEnumerable<FoodStore>> ListAsync();
    Task<FoodStoreResponse> FindByIdAsync(int foodStoreId);
    Task<FoodStoreResponse> SaveAsync(FoodStore foodStore);
    Task<FoodStoreResponse> UpdateAsync(int foodStoreId, FoodStore foodStore);
    Task<FoodStoreResponse> DeleteAsync(int id);
}