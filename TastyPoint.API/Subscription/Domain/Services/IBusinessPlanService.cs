using TastyPoint.API.Subscription.Domain.Models;
using TastyPoint.API.Subscription.Domain.Services.Communication;

namespace TastyPoint.API.Subscription.Domain.Services;

public interface IBusinessPlanService
{
    Task<IEnumerable<BusinessPlan>> ListAsync();
    Task<BusinessPlanResponse> FindByIdAsync(int businessPlanId);
    Task<BusinessPlanResponse> SaveAsync(BusinessPlan businessPlan);
    Task<BusinessPlanResponse> UpdateAsync(int promotionId, BusinessPlan businessPlan);
    Task<BusinessPlanResponse> DeleteAsync(int id);
}