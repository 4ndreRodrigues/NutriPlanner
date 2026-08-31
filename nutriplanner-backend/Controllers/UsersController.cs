using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutriPlanner.Dtos;
using NutriPlanner.Services;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NutriPlanner.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController(IUserService _userService) : ControllerBase
    {
        [HttpPut("me/diet/{dietId:int}")]
        public async Task<IActionResult> setDiet(int dietId)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();

            var success = await _userService.SetDietAsync(userId, dietId);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("me/diet")]
        public async Task<IActionResult> DeleteDiet()
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();

            var success = await _userService.SetDietAsync(userId, null);
            if (!success) return NotFound();

            return NoContent();
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();

            var profile = await _userService.GetProfileAsync(userId);
            if (profile == null) return NotFound();

            return Ok(profile);
        }

        [Authorize]
        [HttpGet("me/safe-foods")]
        public async Task<IActionResult> GetSafeFoods()
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();
            var safeFoods = await _userService.GetSafeFoodsAsync(userId);
            return Ok(safeFoods);
        }
    }
}