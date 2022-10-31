using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TastyPoint.API.Selling.Domain.Models;
using TastyPoint.API.Selling.Domain.Services;
using TastyPoint.API.Selling.Resources;
using TastyPoint.API.Shared.Extensions;

namespace TastyPoint.API.Selling.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PackController:ControllerBase
{
    private readonly IPackService _packService;
    private readonly IMapper _mapper;

    public PackController(IPackService packService, IMapper mapper)
    {
        _packService = packService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PackResource>> GetAllAsync()
    {
        var packs = await _packService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Pack>, IEnumerable<PackResource>>(packs);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePackResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var pack = _mapper.Map<SavePackResource, Pack>(resource);

        var result = await _packService.SaveAsync(pack);

        if (!result.Success)
            return BadRequest(result.Message);

        var packResource = _mapper.Map<Pack, PackResource>(result.Resource);

        return Created(nameof(PostAsync), packResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePackResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var pack = _mapper.Map<SavePackResource, Pack>(resource);

        var result = await _packService.UpdateAsync(id, pack);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var packResource = _mapper.Map<Pack, PackResource>(result.Resource);

        return Ok(packResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _packService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var packResource = _mapper.Map<Pack, PackResource>(result.Resource);

        return Ok(packResource);
    }
}