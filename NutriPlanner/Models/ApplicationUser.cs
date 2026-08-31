using Microsoft.AspNetCore.Identity;

namespace NutriPlanner.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Objetivo { get; set; }
        public int? DietId { get; set; }
        public ICollection<UserFood> Selections { get; set; }
    }
}
