using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriPlanner.Dtos;
using NutriPlanner.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NutriPlanner.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserFoodsController(IUserFoodService _userFoodsService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddUserFood(AddUserFoodDto dto)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();

            var userSelection = await _userFoodsService.AddUserFoodAsync(userId, dto);
            return Ok(userSelection);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserFoods()
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();

            var selections = await _userFoodsService.GetUserFoodsAsync(userId);
            return Ok(selections);
        }

        [HttpDelete("{selectionId}")]
        public async Task<IActionResult> DeleteUserFood(int selectionId)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();

            var result = await _userFoodsService.DeleteUserFoodByFoodIdAsync(userId, selectionId);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
