﻿using TastyPoint.API.Social.Domain.Models;

namespace TastyPoint.API.Social.Domain.Repositories;

public interface IFoodStoreRepository
{
    Task<IEnumerable<FoodStore>> ListAsync();
    Task AddAsync(FoodStore foodStore);
    Task<FoodStore> FindByIdAsync(int id);
    void Update(FoodStore foodStore);
    void Remove(FoodStore foodStore);
}