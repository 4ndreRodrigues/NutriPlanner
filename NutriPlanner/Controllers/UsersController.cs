using Microsoft.AspNetCore.Mvc;
using NutriPlanner.Dtos;
using NutriPlanner.Services;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NutriPlanner.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController(IUserService _userService) : ControllerBase
    {
        [HttpPut("me/diet/{dietId}")]
        public async Task<IActionResult> setDiet(int dietId)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();

            var success = await _userService.SetDietAsync(userId, dietId);
            if (!success) return NotFound();

            return Ok();
        }
    }
}