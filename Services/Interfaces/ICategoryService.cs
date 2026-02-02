using InventoryCore.Api.Dtos.Categories;

namespace InventoryCore.Api.Services.Interfaces;

public interface ICategoryService
{
    CategoryResponseDto Create(CreateCategoryDto dto);

    List<CategoryResponseDto> GetAll();
    
    CategoryResponseDto? GetById(int id);
}

