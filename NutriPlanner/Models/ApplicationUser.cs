using Microsoft.AspNetCore.Identity;

namespace NutriPlanner.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Objetivo { get; set; }
        public int? DietId { get; set; }
        public ICollection<UserFood> Selections { get; set; }
    }
}
