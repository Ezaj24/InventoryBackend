using InventoryCore.Api.Dtos.Products;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InventoryCore.Api.Dtos.Common;

namespace InventoryCore.Api.Services.Interfaces;


public interface IProductService
{
    Task<ProductResponseDto> CreateAsync(CreateProductDto dto);

    Task<PagedResult<ProductResponseDto>> GetAllAsync(
        int page,
        int pageSize,
        int? categoryId,
        string? sortBy,
        string? search);
    
    
    Task<ProductResponseDto?> GetByIdAsync(int id);
    
    Task<ProductResponseDto?> UpdateAsync(int id, CreateProductDto dto);
    
    Task<bool> DeleteAsync(int id);
    
    
}