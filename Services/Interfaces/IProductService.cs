using InventoryCore.Api.Dtos.Products;

namespace InventoryCore.Api.Services.Interfaces;


public interface IProductService
{
    Task<ProductResponseDto> CreateAsync(CreateProductDto dto);

    Task<IEnumerable<ProductResponseDto>> GetAllAsync(
        int page,
        int pageSize,
        int? categoryId,
        string? sortBy,
        string? search);
    
    
    Task<ProductResponseDto?> GetByIdAsync(int id);
    
    Task<ProductResponseDto?> UpdateAsync(int id, CreateProductDto dto);
    
    Task<bool> DeleteAsync(int id);
    
    
}