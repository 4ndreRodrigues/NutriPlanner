using Microsoft.AspNetCore.Mvc;
using NutriPlanner.Dtos;
using NutriPlanner.Services;

namespace NutriPlanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController(IFoodService _foodService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<FoodDto>>> GetAllFoods()
        {
            var foods = await _foodService.GetAllFoodsAsync();
            return Ok(foods);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodDto>> GetFoodById(int id)
        {
            var food = await _foodService.GetFoodByIdAsync(id);
            if (food == null)
                return NotFound();

            return Ok(food);
        }    
    }
}
