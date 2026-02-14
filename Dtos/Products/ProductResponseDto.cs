namespace InventoryCore.Api.Dtos.Products;

public class ProductResponseDto
{
    public int Id  { get; set; } 
    
    public string Name { get; set; } = String.Empty;
    
    public decimal Price { get; set; } 
    
    public int Quantity { get; set; }
    
    public int CategoryId { get; set; }
    
    public DateTime CreatedAt  { get; set; }

    public string CategoryName { get; set; } = string.Empty;
}