using InventoryCore.Api.Dtos.Categories;
using InventoryCore.Api.Services.Interfaces;
using  Microsoft.AspNetCore.Mvc;


namespace InventoryCore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<ActionResult<CategoryResponseDto>> Create(CreateCategoryDto dto)
    {
        var result = await _categoryService.CreateAsync(dto);

        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryResponseDto>>> GetAll()
    {
        var result = await _categoryService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryResponseDto>> Get(int id)
    {
        var result = await _categoryService.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryResponseDto>> Update(int id, CreateCategoryDto dto)
    {
        var result = await _categoryService.UpdateAsync(id, dto);

        if (result == null)
            return NotFound();
        
        return Ok(result);

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _categoryService.DeleteAsync(id);
        if (!deleted)
            return NotFound();
        
        return Ok();
    }
}
