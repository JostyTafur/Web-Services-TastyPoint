using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TastyPoint.API.Ordering.Domain.Models;
using TastyPoint.API.Ordering.Domain.Services;
using TastyPoint.API.Ordering.Resources;
using TastyPoint.API.Shared.Extensions;


namespace TastyPoint.API.Ordering.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class OrderController:ControllerBase
{
     private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<OrderResource>> GetAllAsync()
    {
        var orders = await _orderService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
        return resources;
    }

    [HttpGet("{id}")]
    public async Task<OrderResource> GetByIdAsync(int id)
    {
        var order = await _orderService.FindByIdAsync(id);
        var resource = _mapper.Map<Order, OrderResource>(order.Resource);
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveOrderResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var order = _mapper.Map<SaveOrderResource, Order>(resource);

        var result = await _orderService.SaveAsync(order);

        if (!result.Success)
            return BadRequest(result.Message);

        var orderResource = _mapper.Map<Order,OrderResource>(result.Resource);

        return Created(nameof(PostAsync), orderResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOrderResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var order = _mapper.Map<SaveOrderResource, Order>(resource);

        var result = await _orderService.UpdateAsync(id, order);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var orderResource = _mapper.Map<Order, OrderResource>(result.Resource);

        return Ok(orderResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _orderService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var orderResource = _mapper.Map<Order, OrderResource>(result.Resource);

        return Ok(orderResource);
    }
}
