using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TastyPoint.API.Shared.Extensions;
using TastyPoint.API.Subscription.Domain.Models;
using TastyPoint.API.Subscription.Domain.Services;
using TastyPoint.API.Subscription.Resources;

namespace TastyPoint.API.Subscription.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[Controller]")]
public class BusinessPlanController : ControllerBase
{
    private readonly IBusinessPlanService _businessPlanService;
    private readonly IMapper _mapper;

    public BusinessPlanController(IBusinessPlanService businessPlanService, IMapper mapper)
    {
        _businessPlanService = businessPlanService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<BusinessPlanResource>> GetAllAsync()
    {
        var businessPlan = await _businessPlanService.ListAsync();
        var resources = _mapper.Map<IEnumerable<BusinessPlan>, IEnumerable<BusinessPlanResource>>(businessPlan);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveBusinessPlanResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var businessPlan = _mapper.Map<SaveBusinessPlanResource, BusinessPlan>(resource);

        var result = await _businessPlanService.SaveAsync(businessPlan);

        if (!result.Success)
            return BadRequest(result.Message);

        var businessPlanResource = _mapper.Map<BusinessPlan, BusinessPlanResource>(result.Resource);

        return Ok(businessPlanResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBusinessPlanResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var businessPlan = _mapper.Map<SaveBusinessPlanResource, BusinessPlan>(resource);
        var result = await _businessPlanService.UpdateAsync(id, businessPlan);

        if (!result.Success)
            return BadRequest(result.Message);

        var businessPlanResource = _mapper.Map<BusinessPlan, BusinessPlanResource>(result.Resource);

        return Ok(businessPlanResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _businessPlanService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var businessPlanResource = _mapper.Map<BusinessPlan, BusinessPlanResource>(result.Resource);

        return Ok(businessPlanResource);
    }
}