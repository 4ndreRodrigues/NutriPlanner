using NutriPlanner.Dtos;

namespace NutriPlanner.Services
{
    public interface INutritionApiService
    {
        Task<NutritionInfoDto?> GetNutritionInfoAsync(FoodDto foodDto);
    }
}
