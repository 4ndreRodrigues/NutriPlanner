using Microsoft.AspNetCore.Identity;
using NutriPlanner.Dtos;

namespace NutriPlanner.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto dto);
        Task<LoginResponseDto?> LoginAsync(LoginDto dto);
    }
}
