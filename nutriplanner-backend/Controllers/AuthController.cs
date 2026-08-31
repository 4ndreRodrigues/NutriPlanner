using Microsoft.AspNetCore.Mvc;
using NutriPlanner.Services;
using NutriPlanner.Dtos;

namespace NutriPlanner.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _authService.RegisterAsync(registerDto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginDto loginDto)
        {
            var loginResponse = await _authService.LoginAsync(loginDto);
            if (loginResponse == null)
            {
                return Unauthorized();
            }

            return Ok(loginResponse);
        }
    }
}