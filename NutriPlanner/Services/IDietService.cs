using NutriPlanner.Dtos;
using NutriPlanner.Models;

namespace NutriPlanner.Services
{
    public interface IDietService
    {
        Task<List<DietDto>> GetAllDietsAsync();
        Task<DietDto?> GetDietByIdAsync(int id);
        Task<DietDto> CreateDietAsync(CreateDietDto dto);
        Task<bool> DeleteDietAsync(int id);
        Task<DietDto?> UpdateDietAsync(int id, UpdateDietDto dto);
    }
}
