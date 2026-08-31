using NutriPlanner.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutriPlanner.Services
{
    public interface IUserFoodService
    {
        Task<UserFoodDto> AddUserFoodAsync(string userId, AddUserFoodDto dto);
        Task<List<UserFoodDto>> GetUserFoodsAsync(string userId);
        Task<bool> DeleteUserFoodByFoodIdAsync(string userId, int selectionId);
    }
}
