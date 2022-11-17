using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TastyPoint.API.Shared.Extensions;
using TastyPoint.API.Social.Domain.Models;
using TastyPoint.API.Social.Domain.Services;
using TastyPoint.API.Social.Resources;

namespace TastyPoint.API.Social.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class FoodStoresController: ControllerBase
{
    private readonly IFoodStoreService _foodStoreService;
    private readonly IMapper _mapper;

    public FoodStoresController(IFoodStoreService foodStoreService, IMapper mapper)
    {
        _foodStoreService = foodStoreService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<FoodStoreResource>> GetAllAsync()
    {
        var foodStores = await _foodStoreService.ListAsync();
        var resources = _mapper.Map<IEnumerable<FoodStore>, IEnumerable<FoodStoreResource>>(foodStores);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<FoodStoreResource> GetByIdAsync(int id)
    {
        var foodStore = await _foodStoreService.FindByIdAsync(id);
        var resource = _mapper.Map<FoodStore, FoodStoreResource>(foodStore.Resource);
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveFoodStoreResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var foodStore = _mapper.Map<SaveFoodStoreResource, FoodStore>(resource);

        var result = await _foodStoreService.SaveAsync(foodStore);

        if (!result.Success)
            return BadRequest(result.Message);

        var foodStoreResource = _mapper.Map<FoodStore, FoodStoreResource>(result.Resource);

        return Created(nameof(PostAsync), foodStoreResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFoodStoreResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var foodStore = _mapper.Map<SaveFoodStoreResource, FoodStore>(resource);

        var result = await _foodStoreService.UpdateAsync(id, foodStore);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var foodStoreResource = _mapper.Map<FoodStore, FoodStoreResource>(result.Resource);

        return Ok(foodStoreResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _foodStoreService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var foodStoreResource = _mapper.Map<FoodStore, FoodStoreResource>(result.Resource);

        return Ok(foodStoreResource);
    }
}