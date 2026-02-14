using Microsoft.AspNetCore.Mvc;
using InventoryCore.Api.Services.Interfaces;
using InventoryCore.Api.Dtos.Products;

namespace InventoryCore.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAll()
    {
        return Ok(await _productService.GetAllAsync());
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
        var product = await _productService.CreateAsync(dto);

        if (product == null)
        {
            return NotFound("Category dosent exist");
        }

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);

    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductResponseDto>> Update(int id, CreateProductDto dto)
    {
        var product = await _productService.UpdateAsync(id, dto);
        if (product == null)
        {
            return NotFound();
        }
        
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _productService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }

}