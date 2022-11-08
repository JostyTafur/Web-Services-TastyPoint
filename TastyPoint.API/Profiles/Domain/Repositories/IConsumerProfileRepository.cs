using TastyPoint.API.Profiles.Domain.Models;

namespace TastyPoint.API.Profiles.Domain.Repositories;

public interface IConsumerProfileRepository
{
    Task<IEnumerable<ConsumerProfile>> ListAsync();
    Task AddAsync(ConsumerProfile consumerProfile);
    Task<ConsumerProfile> FindByIdAsync(int id);
    void Update(ConsumerProfile consumerProfile);
    void Remove(ConsumerProfile consumerProfile);
}