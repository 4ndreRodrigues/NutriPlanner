using NutriPlanner.Dtos;

namespace NutriPlanner.Services
{
    public interface IFoodService
    {
        Task<FoodDto?> GetFoodByIdAsync(int id);
        Task<List<FoodDto>> GetAllFoodsAsync();
        Task<NutritionInfoDto> GetNutritionInfoAsync(int foodId);
        Task SaveNutritionInfoAsync(NutritionInfoDto dto);
    }
}