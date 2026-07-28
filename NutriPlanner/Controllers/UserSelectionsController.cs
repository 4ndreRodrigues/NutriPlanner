using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriPlanner.Dtos;
using NutriPlanner.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
    }
}
