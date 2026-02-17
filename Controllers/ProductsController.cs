using Microsoft.AspNetCore.Mvc;
using InventoryCore.Api.Services.Interfaces;
using InventoryCore.Api.Dtos.Products;
using Microsoft.Extensions.Logging;
using InventoryCore.Api.Dtos.Common;
namespace InventoryCore.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductService productService, ILogger<ProductsController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<ProductResponseDto>>> GetAll(
         int page = 1,
         int pageSize = 5,
         int? categoryId = null,
         string? sortBy = null,
         string? search = null)
    {
         return Ok(await _productService.GetAllAsync(page, pageSize, categoryId, sortBy,search));
       
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponseDto>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }
        
        return Ok(product);
        
    }

    [HttpPost]
    public async Task<ActionResult<ProductResponseDto>> Create(CreateProductDto dto)
    {
        var result = await _productService.CreateAsync(dto);

        if (result == null)
        {
            return BadRequest("Invalid Category");
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        _logger.LogInformation("Product created : {ProductName}", result.Name);

    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductResponseDto>> Update(int id, CreateProductDto dto)
    {
        var product = await _productService.UpdateAsync(id, dto);
        if (product == null)
        {
            return NotFound("Product not Found");
        }
        
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _productService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound("Product not found");
        }
        
        return NoContent();
        _logger.LogInformation("Product deleted : {ProductName}", id);
    }

}