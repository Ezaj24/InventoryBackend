using Microsoft.EntityFrameworkCore;
using InventoryCore.Api.Models;

namespace InventoryCore.Api.Data.Seed;

public static class DbSeeder
{
    public static async Task SeedAdminAsync(AppDbContext context)
    {
        if(await context.Users.AnyAsync(u => u.Role == "Admin"))
        return;

        var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();
        
        var admin = new User
        {
            Email = "admin@inventory.com",
            Role = "Admin"
        };
        
        admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");
        
        context.Users.Add(admin);
        await context.SaveChangesAsync();
        
    }
}