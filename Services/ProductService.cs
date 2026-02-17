using System.Xml;
using InventoryCore.Api.Data;
using InventoryCore.Api.Services.Interfaces;
using InventoryCore.Api.Dtos.Products;
using InventoryCore.Api.Models;
using Microsoft.EntityFrameworkCore;
using InventoryCore.Api.Dtos.Common;
using Microsoft.AspNetCore.Http.Features;

namespace InventoryCore.Api.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext  _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
    {
        var result = await _context.Categories.AnyAsync(x => x.Id == dto.CategoryId);
            if (!result)
            {
                return null;
            }

            var product = new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                Quantity = dto.Quantity,
                CategoryId = dto.CategoryId

            };
            
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            
            return new  ProductResponseDto()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Quantity = product.Quantity,
                CreatedAt = product.CreatedAt
            };
        
        
    }

    public async Task<PagedResult<ProductResponseDto>> GetAllAsync(
        int page,
        int pageSize,
        int? categoryId,
        string? sortBy,
        string? search)
    {
        var query = _context.Products.AsQueryable();

        // filter by category
        if (categoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == categoryId.Value);
        }

        // search by name
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p => p.Name.ToLower().Contains(search.ToLower()));
        }

        // sorting
        query = sortBy?.ToLower() switch
        {
            "price" => query.OrderBy(p => p.Price),
            "name" => query.OrderBy(p => p.Name),
            "newest" => query.OrderByDescending(p => p.CreatedAt),
            _ => query.OrderByDescending(p => p.CreatedAt)
        };

        // pagination
       
        var totalCount = await query.CountAsync();
        
        var skip = (page - 1) * pageSize;
        
        var items = await query
            .Skip(skip)
            .Take(pageSize)
            .Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                CreatedAt = p.CreatedAt
            })
            .ToListAsync();
        
        return new PagedResult<ProductResponseDto>
        {
            Items = items,
            TotalCount = totalCount
        };
    
        
    }
    

    public async Task<ProductResponseDto?> GetByIdAsync(int id)
    {
        return await _context.Products
            .AsNoTracking()
            .Select(x => new  ProductResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                CreatedAt = x.CreatedAt,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name
                
            })
            .FirstOrDefaultAsync(x => x.Id == id);
        
            
    }

    public async Task<ProductResponseDto?> UpdateAsync(int id, CreateProductDto dto)
    {
       var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
       if (result == null)
       {
           return null;
       }
       var exists = await _context.Categories.AnyAsync(x => x.Id == dto.CategoryId);
       if (!exists)
       {
           return null;
       }

       
       result.Name = dto.Name;
       result.Price = dto.Price;
       result.Quantity = dto.Quantity;
       result.CategoryId = dto.CategoryId;
       
       await _context.SaveChangesAsync();

       var categoryname = await _context.Categories
           .Where(x => x.Id == dto.CategoryId)
           .Select(x => x.Name)
           .FirstAsync();

       return new ProductResponseDto()
       {
           Id = result.Id,
           Name = result.Name,
           Price = result.Price,
           Quantity = result.Quantity,
           CategoryId = result.CategoryId,
           CategoryName = categoryname,
           CreatedAt = result.CreatedAt
           
       };


    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (result == null)
        {
            return false;
        }
        
        _context.Products.Remove(result);
        await _context.SaveChangesAsync();
        
        return true;
        
            
    }
}

