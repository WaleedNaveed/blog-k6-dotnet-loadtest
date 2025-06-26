using K6LoadTestDemo.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GetProductById = K6LoadTestDemo.DTOs.GetProductById;

namespace K6LoadTestDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("public")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _productService.GetAllProductsAsync();
        return Ok(response);
    }

    [Authorize]
    [HttpGet("secure")]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        var request = new GetProductById.Request { Id = id };
        var response = await _productService.GetProductByIdAsync(request);
        return Ok(response);
    }
}