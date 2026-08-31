using Microsoft.AspNetCore.Mvc;
using NutriPlanner.Dtos;
using NutriPlanner.Services;

namespace NutriPlanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController(IFoodService _foodService, INutritionApiService _nutritionApiService) : ControllerBase
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

        [HttpGet("{id}/nutrition")]
        public async Task<ActionResult<NutritionInfoDto>> GetNutritionInfo(int id)
        {
            var cachedNutritionInfo = await _foodService.GetNutritionInfoAsync(id);
            if (cachedNutritionInfo != null)
                return Ok(cachedNutritionInfo);

            var food = await _foodService.GetFoodByIdAsync(id);
            if (food == null) return NotFound();

            var nutritionInfo = await _nutritionApiService.GetNutritionInfoAsync(food);
            if (nutritionInfo == null) return NotFound("Nutrition data not found");

            await _foodService.SaveNutritionInfoAsync(nutritionInfo);

            return Ok(nutritionInfo);
        }
    }
}
