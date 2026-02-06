using InventoryCore.Api.Dtos.Categories;

namespace InventoryCore.Api.Services.Interfaces;

public interface ICategoryService
{
    Task<CategoryResponseDto> CreateAsync(CreateCategoryDto dto);
    Task<List<CategoryResponseDto>> GetAllAsync();
    Task<CategoryResponseDto?> GetByIdAsync(int id);
    Task<CategoryResponseDto?> UpdateAsync(int id, CreateCategoryDto dto);
    Task<bool> DeleteAsync(int id);
    
}
