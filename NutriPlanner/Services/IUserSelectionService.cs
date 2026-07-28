using NutriPlanner.Dtos;
using System.Threading.Tasks;

namespace NutriPlanner.Services
{
    public interface IUserSelectionService
    {
        Task<UserSelectionDto> AddSelectionAsync(string userId, AddSelectionDto dto);
    }
}
