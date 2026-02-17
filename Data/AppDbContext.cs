using Microsoft.EntityFrameworkCore;
using InventoryCore.Api.Models;

namespace InventoryCore.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Product> Products { get; set; } 
    
    public DbSet<User> Users { get; set; }
}