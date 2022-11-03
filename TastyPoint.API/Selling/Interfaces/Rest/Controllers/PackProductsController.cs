using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TastyPoint.API.Selling.Domain.Models;
using TastyPoint.API.Selling.Domain.Services;
using TastyPoint.API.Selling.Resources;
using TastyPoint.API.Shared.Extensions;

namespace TastyPoint.API.Selling.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/packs/{packId}/products")]
[Produces(MediaTypeNames.Application.Json)]
public class PackProductsController: ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public PackProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductResource>> GetAllByPackIdAsync(int packId)
    {
        var products = await _productService.ListByPackIdAsync(packId);

        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        return resources;
    }
    
}