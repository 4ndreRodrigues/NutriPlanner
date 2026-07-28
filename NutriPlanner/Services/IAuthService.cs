using Microsoft.AspNetCore.Identity;
using NutriPlanner.Dtos;

namespace NutriPlanner.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
    }
}
