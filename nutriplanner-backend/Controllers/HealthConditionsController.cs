using Microsoft.AspNetCore.Mvc;
using NutriPlanner.Dtos;
using NutriPlanner.Models;
using NutriPlanner.Services;

namespace NutriPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthConditionsController(IHealthConditionService _healthConditionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllHealthConditions()
        {
            var healthConditions = await _healthConditionService.GetAllHealthConditionsAsync();
            return Ok(healthConditions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHealthConditionById(int id)
        {
            var healthCondition = await _healthConditionService.GetHealthConditionByIdAsync(id);
            if (healthCondition == null)
            {
                return NotFound();
            }
            return Ok(healthCondition);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHealthCondition(CreateHealthConditionDto dto)
        {
            var createdHealthCondition = await _healthConditionService.CreateHealthConditionAsync(dto);
            return CreatedAtAction(nameof(GetHealthConditionById), new { id = createdHealthCondition.Id }, createdHealthCondition);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHealthCondition(int id)
        {
            var result = await _healthConditionService.DeleteHealthConditionAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HealthConditionDto>> UpdateHealthCondition(int id, UpdateHealthConditionDto dto)
        {
            try
            {
                var updatedHealthCondition = await _healthConditionService.UpdateHealthConditionAsync(id, dto);
                return Ok(updatedHealthCondition);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

        }

        [HttpGet("{id}/foods")]
        public async Task<ActionResult<List<HealthConditionFoodDto>>> GetFoodsByHealthConditionId(int id)
        {
            var healthCondition = await _healthConditionService.GetHealthConditionByIdAsync(id);
            if (healthCondition == null)
            {
                return NotFound();
            }
            var foods = await _healthConditionService.GetFoodsByHealthConditionIdAsync(id);
            return Ok(foods);
        }
    }
}
