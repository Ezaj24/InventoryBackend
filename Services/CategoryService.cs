using InventoryCore.Api.Dtos.Categories;
using InventoryCore.Api.Models;
using InventoryCore.Api.Services.Interfaces;

namespace InventoryCore.Api.Services;

public class CategoryService : ICategoryService
{
    // This is temporary storage (in-memory)
    private static readonly List<Category> _categories = new();
    private static int _nextId = 1;

    public CategoryResponseDto Create(CreateCategoryDto dto)
    {
        var category = new Category
        {
            Id = _nextId++,
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        _categories.Add(category);

        return new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            CreatedAt = category.CreatedAt
        };
    }

    public List<CategoryResponseDto> GetAll()
    {
        return _categories
            .Select(c => new CategoryResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                CreatedAt = c.CreatedAt
            })
            .ToList();
    }

    public CategoryResponseDto? GetById(int id)
    {
        var category = _categories.FirstOrDefault(c => c.Id == id);

        if (category == null)
            return null;

        return new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            CreatedAt = category.CreatedAt
        };
    }
}