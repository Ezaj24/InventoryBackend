using System.ComponentModel.DataAnnotations;

namespace InventoryCore.Api.Dtos.Categories;

public class CreateCategoryDto
{
    [Required] 
    [MinLength(2)]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(250)]
    public string? Description { get; set; } 

}