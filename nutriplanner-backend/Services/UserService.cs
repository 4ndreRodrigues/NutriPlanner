using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NutriPlanner.Data;
using NutriPlanner.Dtos;
using NutriPlanner.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutriPlanner.Services
{
    public class UserService(UserManager<ApplicationUser> _userManager, ApplicationDbContext _context) : IUserService
    {
        public async Task<bool> SetDietAsync(string userId, int? dietId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            user.DietId = dietId;

            await _userManager.UpdateAsync(user);
            return true;
        }

        public async Task<UserProfileDto?> GetProfileAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return null;

            string? dietName = null;
            if (user.DietId != null)
            {
                var diet = await _context.Diets.FindAsync(user.DietId);
                dietName = diet?.Name;
            }

            return new UserProfileDto
            {
                Id = user.Id,
                Email = user.Email!,
                DietId = user.DietId,
                DietName = dietName,
                Name = user.Name,
                LastName = user.LastName,
                BirthDate = user.BirthDate
            };
        }

        public async Task<List<SafeFoodDto>> GetSafeFoodsAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null || user.DietId == null) return new List<SafeFoodDto>();

            // 1. Obter todos os alimentos da dieta do utilizador
            var dietFoodIds = await _context.DietFoods
                .Where(df => df.DietId == user.DietId)
                .Select(df => df.FoodId)
                .ToListAsync();

            // 2. Obter as condições de saúde do utilizador
            var userHealthConditionsIds = await _context.UserHealthConditions
                .Where(uhc => uhc.UserId == userId)
                .Select(uhc => uhc.HealthConditionId)
                .ToListAsync();

            // 3. Obter restrições/severidades para esses alimentos
            var restrictions = await _context.HealthConditionFoods
                .Where(hcf => userHealthConditionsIds.Contains(hcf.HealthConditionId) && dietFoodIds.Contains(hcf.FoodId))
                .ToListAsync();

            // Mapear a severidade e a razão (Reason) de cada alimento com base nas condições do utilizador
            var foodSeverityMap = new Dictionary<int, string>();
            var foodReasonMap = new Dictionary<int, string?>();

            foreach (var dietFoodId in dietFoodIds)
            {
                //Filtrar restrições estritamente para este alimento específico(dietFoodId)
                var foodRestrictions = restrictions.Where(r => r.FoodId == dietFoodId).ToList();
                // Verificar restrições para este alimento nas condições do utilizador
                var avoidRestriction = foodRestrictions.FirstOrDefault(r => r.Severity == FoodSeverity.Avoid);
                var moderateRestriction = foodRestrictions.FirstOrDefault(r => r.Severity == FoodSeverity.Moderate);

                if (avoidRestriction != null)
                {
                    foodSeverityMap[dietFoodId] = "Avoid";
                    foodReasonMap[dietFoodId] = avoidRestriction.Reason;
                }
                else if (moderateRestriction != null)
                {
                    foodSeverityMap[dietFoodId] = "Moderate";
                    foodReasonMap[dietFoodId] = moderateRestriction.Reason;
                }
                else
                {
                    foodSeverityMap[dietFoodId] = "Safe";
                    foodReasonMap[dietFoodId] = null;
                }
            }

            var foods = await _context.Foods
                .Where(f => dietFoodIds.Contains(f.Id))
                .ToListAsync();

            return foods.Select(f => new SafeFoodDto
            {
                Id = f.Id,
                Name = f.Name,
                Category = f.Category,
                Severity = foodSeverityMap.TryGetValue(f.Id, out var sev) ? sev : "Safe",
                Reason = foodReasonMap.TryGetValue(f.Id, out var reason) ? reason : null
            }).ToList();
        }
    }
}

    
    
