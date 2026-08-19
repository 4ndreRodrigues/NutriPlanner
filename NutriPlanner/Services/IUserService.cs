using Microsoft.AspNetCore.Identity;
using NutriPlanner.Dtos;
using System.Threading.Tasks;

namespace NutriPlanner.Services
{
    public interface IUserService
    {
        Task<bool> SetDietAsync(string userId, int dietId);
    }
}
