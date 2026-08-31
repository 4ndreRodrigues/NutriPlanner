using Microsoft.EntityFrameworkCore;
using NutriPlanner.Data;
using NutriPlanner.Dtos;
using NutriPlanner.Models;

namespace NutriPlanner.Services
{
    public class FoodService(ApplicationDbContext _context) : IFoodService
    {
        public async Task<FoodDto?> GetFoodByIdAsync(int id)
        {
            var food = await _context.Foods.FindAsync(id);

            if (food == null)
                return null;

            return new FoodDto
            {
                Id = food.Id,
                Name = food.Name,
                SearchTerm = food.SearchTerm,
                Category = food.Category,
                ExternalFoodId = food.ExternalFoodId
            };
        }

        public async Task<List<FoodDto>> GetAllFoodsAsync()
        {
            return await _context.Foods
                .Select(f => new FoodDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    SearchTerm = f.SearchTerm,
                    Category = f.Category,
                    ExternalFoodId = f.ExternalFoodId
                })
                .ToListAsync();
        }

        public async Task<NutritionInfoDto> GetNutritionInfoAsync(int foodId)
        {
            var food = await _context.Foods.FindAsync(foodId);
            if (food == null)
                return null;

            if (food.NutritionInfo == null)
                return null;

            return new NutritionInfoDto
            {
                FoodId = food.NutritionInfo.FoodId,
                ExternalFoodId = food.NutritionInfo.ExternalFoodId,
                LastUpdated = food.NutritionInfo.LastUpdated,
                Calories = food.NutritionInfo.Calories,
                Protein = food.NutritionInfo.Protein,
                Carbs = food.NutritionInfo.Carbs,
                Fat = food.NutritionInfo.Fat
            };
        }

        public async Task SaveNutritionInfoAsync(NutritionInfoDto dto)
        {
            var existing = await _context.NutritionInfos.FindAsync(dto.FoodId);
            if (existing != null)
            {
                existing.Calories = dto.Calories;
                existing.Protein = dto.Protein;
                existing.Carbs = dto.Carbs;
                existing.Fat = dto.Fat;
                existing.LastUpdated = dto.LastUpdated;
            }
            else
            {
                _context.NutritionInfos.Add(new NutritionInfo
                {
                    FoodId = dto.FoodId,
                    ExternalFoodId = dto.ExternalFoodId,
                    Calories = dto.Calories,
                    Protein = dto.Protein,
                    Carbs = dto.Carbs,
                    Fat = dto.Fat,
                    LastUpdated = dto.LastUpdated
                });
            }

            var food = await _context.Foods.FindAsync(dto.FoodId);
            if (food != null && food.ExternalFoodId != null)
            {
                food.ExternalFoodId = dto.ExternalFoodId;
            }

            await _context.SaveChangesAsync();
        }
    }
}
