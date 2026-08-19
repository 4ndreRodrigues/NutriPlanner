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
    public class UserService(UserManager<ApplicationUser> _userManager) : IUserService
    {
        public async Task<bool> SetDietAsync(string userId, int dietId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            user.DietId = dietId;

            await _userManager.UpdateAsync(user);
            return true;
        }
    }
}
