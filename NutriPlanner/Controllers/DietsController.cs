using Microsoft.AspNetCore.Mvc;
using NutriPlanner.Dtos;
using NutriPlanner.Models;
using NutriPlanner.Services;

namespace NutriPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietsController(IDietService _dietService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDiets()
        {
            var diets = await _dietService.GetAllDietsAsync();
            return Ok(diets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDietById(int id)
        {
            var diet = await _dietService.GetDietByIdAsync(id);
            if (diet == null)
            {
                return NotFound();
            }
            return Ok(diet);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiet(CreateDietDto dto)
        {
            var createdDiet = await _dietService.CreateDietAsync(dto);
            return CreatedAtAction(nameof(GetDietById), new { id = createdDiet.Id }, createdDiet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiet(int id)
        {
            var result = await _dietService.DeleteDietAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DietDto>> UpdateDiet(int id, UpdateDietDto dto)
        {
            try
            {
                var updatedDiet = await _dietService.UpdateDietAsync(id, dto);
                return Ok(updatedDiet);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

        }
    }
}
