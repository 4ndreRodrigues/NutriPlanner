using NutriPlanner.Data;
using NutriPlanner.Models;
using Microsoft.EntityFrameworkCore;
using NutriPlanner.Dtos;

namespace NutriPlanner.Services
{
    public class HealthConditionService(ApplicationDbContext _context) : IHealthConditionService
    {
        public async Task<HealthConditionDto> CreateHealthConditionAsync(CreateHealthConditionDto dto)
        {
            var healthCondition = new HealthCondition
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _context.HealthConditions.Add(healthCondition);
            await _context.SaveChangesAsync();

            return new HealthConditionDto
            {
                Id = healthCondition.Id,
                Name = healthCondition.Name,
                Description = healthCondition.Description
            };
        }

        public async Task<bool> DeleteHealthConditionAsync(int id)
        {
            var healthConditionToDelete = await _context.HealthConditions.FindAsync(id);
            if (healthConditionToDelete == null)
            {
                return false;
            }
            _context.HealthConditions.Remove(healthConditionToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<HealthConditionDto>> GetAllHealthConditionsAsync()
        {
            var healthConditions = await _context.HealthConditions.ToListAsync();
            return healthConditions.Select(hc => new HealthConditionDto
            {
                Id = hc.Id,
                Name = hc.Name,
                Description = hc.Description
            }).ToList();
        }

        public async Task<HealthConditionDto?> GetHealthConditionByIdAsync(int id)
        {
            var healthCondition = await _context.HealthConditions.FindAsync(id);
            if (healthCondition == null) {
                return null;
            }
            return new HealthConditionDto
            {
                Id = healthCondition.Id,
                Name = healthCondition.Name,
                Description = healthCondition.Description
            };
        }

        public async Task<HealthConditionDto?> UpdateHealthConditionAsync(int id, UpdateHealthConditionDto dto)
        {
            var healthConditionToUpdate = await _context.HealthConditions.FindAsync(id);
            if (healthConditionToUpdate == null)
            {
                return null;
            }

            healthConditionToUpdate.Name = dto.Name;
            healthConditionToUpdate.Description = dto.Description;

            await _context.SaveChangesAsync();

            return new HealthConditionDto
            {
                Id = healthConditionToUpdate.Id,
                Name = healthConditionToUpdate.Name,
                Description = healthConditionToUpdate.Description
            };
        }

        public async Task<List<HealthConditionFoodDto>> GetFoodsByHealthConditionIdAsync(int id)
        {
            return await _context.HealthConditionFoods
                .Where(hcf => hcf.HealthConditionId == id)
                .Select(hcf => new HealthConditionFoodDto
                {
                    Id = hcf.Food.Id,
                    Name = hcf.Food.Name,
                    Category = hcf.Food.Category,
                    Severity = hcf.Severity.ToString()
                })
                .ToListAsync();
        }
    }
}
