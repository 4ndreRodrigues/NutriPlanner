using Microsoft.EntityFrameworkCore;
using NutriPlanner.Data;
using NutriPlanner.Dtos;

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
                    Category = f.Category,
                    ExternalFoodId = f.ExternalFoodId
                })
                .ToListAsync();
        }

    }
}
