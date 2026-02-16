using System.ComponentModel.DataAnnotations;

namespace InventoryCore.Api.Dtos.Products;

public class CreateProductDto
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; } = string.Empty;
    
    [Range(1,double.MaxValue)]
    public decimal Price { get; set; }
    
    [Range(0,int.MaxValue)]
    public int Quantity { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
}