using NutriPlanner.Data;
using NutriPlanner.Models;
using Microsoft.EntityFrameworkCore;
using NutriPlanner.Dtos;

namespace NutriPlanner.Services
{
    public class DietService(ApplicationDbContext _context) : IDietService
    {
        public async Task<DietDto> CreateDietAsync(CreateDietDto dto)
        {
            var diet = new Diet
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _context.Diets.Add(diet);
            await _context.SaveChangesAsync();

            return new DietDto
            {
                Id = diet.Id,
                Name = diet.Name,
                Description = diet.Description
            };
        }

        public async Task<bool> DeleteDietAsync(int id)
        {
            var dietToDelete = await _context.Diets.FindAsync(id);
            if (dietToDelete == null)
            {
                return false;
            }
            _context.Diets.Remove(dietToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<DietDto>> GetAllDietsAsync()
        {
            var diets = await _context.Diets.ToListAsync();
            return diets.Select(d => new DietDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            }).ToList();
        }

        public async Task<DietDto?> GetDietByIdAsync(int id)
        {
            var diet = await _context.Diets.FindAsync(id);
            if (diet == null) {
                return null;
            }
            return new DietDto
            {
                Id = diet.Id,
                Name = diet.Name,
                Description = diet.Description
            };
        }

        public async Task<DietDto?> UpdateDietAsync(int id, UpdateDietDto dto)
        {
            var dietToUpdate = await _context.Diets.FindAsync(id);
            if (dietToUpdate == null)
            {
                return null;
            }

            dietToUpdate.Name = dto.Name;
            dietToUpdate.Description = dto.Description;

            await _context.SaveChangesAsync();

            return new DietDto
            {
                Id = dietToUpdate.Id,
                Name = dietToUpdate.Name,
                Description = dietToUpdate.Description
            };
        }

        public async Task<List<FoodDto>> GetFoodsByDietIdAsync(int id)
        {
            return await _context.DietFoods
                .Where(df => df.DietId == id)
                .Select(df => new FoodDto
                {
                    Id = df.Food.Id,
                    Name = df.Food.Name,
                    Category = df.Food.Category,
                })
                .ToListAsync();
        }
    }
}
