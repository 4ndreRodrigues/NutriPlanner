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
        public async Task<bool> SetDietAsync(string userId, int dietId)
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
                DietName = dietName
            };
        }
    }
}

    
    
