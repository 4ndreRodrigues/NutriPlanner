using NutriPlanner.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutriPlanner.Services
{
    public interface IUserHealthConditionService
    {
        Task<UserHealthConditionDto> AddUserHealthConditionAsync(string userId, AddUserHealthConditionDto dto);
        Task<List<UserHealthConditionDto>> GetUserHealthConditionsAsync(string userId);
        Task<bool> DeleteUserHealthConditionByHealthConditionIdAsync(string userId, int selectionId);
    }
}
