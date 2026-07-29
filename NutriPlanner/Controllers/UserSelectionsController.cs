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
    public class UserSelectionsController(IUserSelectionService _userSelectionService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddSelection(AddSelectionDto dto)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();

            var userSelection = await _userSelectionService.AddSelectionAsync(userId, dto);
            return Ok(userSelection);
        }

        [HttpGet]
        public async Task<IActionResult> GetSelections()
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();

            var selections = await _userSelectionService.GetSelectionsAsync(userId);
            return Ok(selections);
        }

        [HttpDelete("{selectionId}")]
        public async Task<IActionResult> DeleteSelection(int selectionId)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();

            var result = await _userSelectionService.DeleteSelectionByFoodIdAsync(userId, selectionId);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
