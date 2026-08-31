using NutriPlanner.Dtos;

namespace NutriPlanner.Services
{
    public interface IHealthConditionService
    {
        Task<List<HealthConditionDto>> GetAllHealthConditionsAsync();
        Task<HealthConditionDto?> GetHealthConditionByIdAsync(int id);
        Task<HealthConditionDto> CreateHealthConditionAsync(CreateHealthConditionDto dto);
        Task<bool> DeleteHealthConditionAsync(int id);
        Task<HealthConditionDto?> UpdateHealthConditionAsync(int id, UpdateHealthConditionDto dto);
        Task<List<HealthConditionFoodDto>> GetFoodsByHealthConditionIdAsync(int id);
    }
}
