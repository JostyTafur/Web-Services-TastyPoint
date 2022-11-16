using TastyPoint.API.Profiles.Domain.Models;
using TastyPoint.API.Profiles.Domain.Services.Communication;

namespace TastyPoint.API.Profiles.Domain.Services;

public interface IUserProfileService
{
    Task<IEnumerable<UserProfile>> ListAsync();
    Task<UserProfileResponse> FindByIdAsync(int userProfileId);
    Task<UserProfileResponse> SaveAsync(UserProfile userProfile);
    Task<UserProfileResponse> UpdateAsync(int userProfileId, UserProfile userProfile);
    Task<UserProfileResponse> DeleteAsync(int id);
}