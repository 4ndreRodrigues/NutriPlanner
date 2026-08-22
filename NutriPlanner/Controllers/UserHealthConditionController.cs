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
    public class UserHealthConditionController(IUserHealthConditionService _userHealthConditionsService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddUserHealthCondition(AddUserHealthConditionDto dto)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();

            var userHealthCondition = await _userHealthConditionsService.AddUserHealthConditionAsync(userId, dto);
            return Ok(userHealthCondition);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserHealthConditions()
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();

            var userHealthConditions = await _userHealthConditionsService.GetUserHealthConditionsAsync(userId);
            return Ok(userHealthConditions);
        }

        [HttpDelete("{healthConditionId}")]
        public async Task<IActionResult> DeleteUserHealthCondition(int healthConditionId)
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId == null) return Unauthorized();

            var result = await _userHealthConditionsService.DeleteUserHealthConditionByHealthConditionIdAsync(userId, healthConditionId);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
