using InventoryCore.Api.Dtos.Auth;

namespace InventoryCore.Api.Services.Interfaces;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterDto dto);
    Task<string?> LoginAsync(LoginDto dto);
}