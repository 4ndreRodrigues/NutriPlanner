using Microsoft.EntityFrameworkCore;
using NutriPlanner.Data;
using NutriPlanner.Dtos;
using NutriPlanner.Models;

namespace NutriPlanner.Services
{
    public class UserSelectionService(ApplicationDbContext _context) : IUserSelectionService
    {
        public async Task<UserSelectionDto> AddSelectionAsync(string userId, AddSelectionDto dto)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) {
                throw new InvalidOperationException("User not found");
            }

            var food = await _context.Foods.FindAsync(dto.FoodId);
            if (food == null) {
                throw new InvalidOperationException("Food not found");
            }

            var foodAlreadySelected = await _context.UserSelections
                .AnyAsync<UserSelection>(us => us.UserId == userId && us.FoodId == dto.FoodId);

            if (foodAlreadySelected)
            {
                throw new InvalidOperationException("Food already selected");
            }

            var selection = new UserSelection
            {
                UserId = userId,
                User = user,
                FoodId = dto.FoodId,
                Food = food,
                AddedAt = DateTime.UtcNow
            };

            _context.UserSelections.Add(selection);
            await _context.SaveChangesAsync();

            return new UserSelectionDto
            {
                Id = selection.Id,
                FoodId = selection.FoodId,
                FoodName = food.Name,
                AddedAt = selection.AddedAt
            };
        }
    }
}
