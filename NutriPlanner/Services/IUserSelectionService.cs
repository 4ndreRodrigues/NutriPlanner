using NutriPlanner.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutriPlanner.Services
{
    public interface IUserSelectionService
    {
        Task<UserSelectionDto> AddSelectionAsync(string userId, AddSelectionDto dto);
        Task<List<UserSelectionDto>> GetSelectionsAsync(string userId);
        Task<bool> DeleteSelectionByFoodIdAsync(string userId, int selectionId);
    }
}
