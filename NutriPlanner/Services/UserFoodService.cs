using Microsoft.EntityFrameworkCore;
using NutriPlanner.Data;
using NutriPlanner.Dtos;
using NutriPlanner.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutriPlanner.Services
{
    public class UserFoodService(ApplicationDbContext _context) : IUserFoodService
    {
        public async Task<UserFoodDto> AddUserFoodAsync(string userId, AddUserFoodDto dto)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) {
                throw new InvalidOperationException("User not found");
            }

            var food = await _context.Foods.FindAsync(dto.FoodId);
            if (food == null) {
                throw new InvalidOperationException("Food not found");
            }

            var foodAlreadySelected = await _context.UserFoods
                .AnyAsync<UserFood>(uf => uf.UserId == userId && uf.FoodId == dto.FoodId);

            if (foodAlreadySelected)
            {
                throw new InvalidOperationException("Food already selected");
            }

            var selection = new UserFood
            {
                UserId = userId,
                User = user,
                FoodId = dto.FoodId,
                Food = food,
                AddedAt = DateTime.UtcNow
            };

            _context.UserFoods.Add(selection);
            await _context.SaveChangesAsync();

            return new UserFoodDto
            {
                Id = selection.Id,
                FoodId = selection.FoodId,
                FoodName = food.Name,
                AddedAt = selection.AddedAt
            };
        }

        public async Task<List<UserFoodDto>> GetUserFoodsAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            var selections= await _context.UserFoods
                .Where(us => us.UserId == userId)
                .Select(s => new UserFoodDto
                {
                    Id = s.Id,
                    FoodId = s.FoodId,
                    FoodName = s.Food.Name,
                    AddedAt = s.AddedAt
                })
                .ToListAsync();

            return selections;
        }

        public async Task<bool> DeleteUserFoodByFoodIdAsync(string userId, int selectionId)
        {
            var selection = await _context.UserFoods
                .FirstOrDefaultAsync(us => us.FoodId == selectionId && us.UserId == userId);
            if (selection == null)
            {
                return false;
            }
            _context.UserFoods.Remove(selection);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
