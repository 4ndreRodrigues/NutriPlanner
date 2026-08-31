using Microsoft.EntityFrameworkCore;
using NutriPlanner.Data;
using NutriPlanner.Dtos;
using NutriPlanner.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutriPlanner.Services
{
    public class UserHealthConditionService(ApplicationDbContext _context) : IUserHealthConditionService
    {
        public async Task<UserHealthConditionDto> AddUserHealthConditionAsync(string userId, AddUserHealthConditionDto dto)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) {
                throw new InvalidOperationException("User not found");
            }

            var healthCondition = await _context.HealthConditions.FindAsync(dto.HealthConditionId);
            if (healthCondition == null) {
                throw new InvalidOperationException("Health condition not found");
            }

            var healthConditionAlreadySelected = await _context.UserHealthConditions
                .AnyAsync<UserHealthCondition>(uhc => uhc.UserId == userId && uhc.HealthConditionId == dto.HealthConditionId);

            if (healthConditionAlreadySelected)
            {
                throw new InvalidOperationException("Health condition already selected");
            }

            var selection = new UserHealthCondition
            {
                UserId = userId,
                User = user,
                HealthConditionId = dto.HealthConditionId,
                HealthCondition = healthCondition,
            };

            _context.UserHealthConditions.Add(selection);
            await _context.SaveChangesAsync();

            return new UserHealthConditionDto
            {
                Id = selection.Id,
                HealthConditionId = selection.HealthConditionId,
                HealthConditionName = selection.HealthCondition.Name,
            };
        }

        public async Task<List<UserHealthConditionDto>> GetUserHealthConditionsAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            var selections= await _context.UserHealthConditions
                .Where(us => us.UserId == userId)
                .Select(s => new UserHealthConditionDto
                {
                    Id = s.Id,
                    HealthConditionId = s.HealthConditionId,
                    HealthConditionName = s.HealthCondition.Name
                })
                .ToListAsync();

            return selections;
        }

        public async Task<bool> DeleteUserHealthConditionByHealthConditionIdAsync(string userId, int selectionId)
        {
            var selection = await _context.UserHealthConditions
                .FirstOrDefaultAsync(us => us.HealthConditionId == selectionId && us.UserId == userId);
            if (selection == null)
            {
                return false;
            }
            _context.UserHealthConditions.Remove(selection);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
