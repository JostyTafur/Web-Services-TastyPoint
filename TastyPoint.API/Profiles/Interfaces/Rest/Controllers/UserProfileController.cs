using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TastyPoint.API.Profiles.Domain.Models;
using TastyPoint.API.Profiles.Domain.Services;
using TastyPoint.API.Profiles.Resources;
using TastyPoint.API.Shared.Extensions;

namespace TastyPoint.API.Profiles.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UserProfileController: ControllerBase
{
    private readonly IUserProfileService _userProfileService;
    private readonly IMapper _mapper;

    public UserProfileController(IUserProfileService userProfileService, IMapper mapper)
    {
        _userProfileService = userProfileService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<UserProfileResource> GetByIdAsync(int id)
    {
        var userprofile = await _userProfileService.FindByIdAsync(id);
        var resource = _mapper.Map<UserProfile, UserProfileResource>(userprofile.Resource);
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveUserProfileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var userprofile = _mapper.Map<SaveUserProfileResource, UserProfile>(resource);

        var result = await _userProfileService.SaveAsync(userprofile);

        if (!result.Success)
            return BadRequest(result.Message);

        var userprofileResource = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);

        return Created(nameof(PostAsync), userprofileResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserProfileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var userprofile = _mapper.Map<SaveUserProfileResource, UserProfile>(resource);

        var result = await _userProfileService.UpdateAsync(id, userprofile);

        if (!result.Success)
            return BadRequest(result.Message);

        var userprofileResource = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);

        return Ok(userprofileResource);
    }
    
    [HttpDelete("id")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _userProfileService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var userProfileResource = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);

        return Ok(userProfileResource);
    }
}