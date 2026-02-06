namespace InventoryCore.Api.Dtos.Categories;
using System.ComponentModel.DataAnnotations;

public class CategoryResponseDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
}