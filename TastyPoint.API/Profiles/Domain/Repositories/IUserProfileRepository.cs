using TastyPoint.API.Profiles.Domain.Models;

namespace TastyPoint.API.Profiles.Domain.Repositories;

public interface IConsumerProfileRepository
{
    Task<IEnumerable<UserProfile>> ListAsync();
    Task AddAsync(UserProfile consumerProfile);
    Task<UserProfile> FindByIdAsync(int id);
    void Update(UserProfile consumerProfile);
    void Remove(UserProfile consumerProfile);
}