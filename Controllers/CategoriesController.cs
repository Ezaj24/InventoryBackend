using InventoryCore.Api.Dtos.Categories;
using InventoryCore.Api.Services.Interfaces;
using  Microsoft.AspNetCore.Mvc;


namespace InventoryCore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    
    public CategoriesController(ICategoryService  categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public ActionResult<CategoryResponseDto> Create(CreateCategoryDto dto)
    {
        var result = _categoryService.Create(dto);
        return Ok(result);
    }

    [HttpGet]
    public ActionResult<List<CategoryResponseDto>> GetAll()
    {
        var result = _categoryService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<CategoryResponseDto> GetById(int id)
    {
        var result = _categoryService.GetById(id);
        if(result == null)
            return NotFound();
        
        return Ok(result);
    }
}