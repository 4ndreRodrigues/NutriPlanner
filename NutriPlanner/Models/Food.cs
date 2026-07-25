using System.ComponentModel.DataAnnotations;

namespace NutriPlanner.Models
{
    public class Food
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? SearchTerm { get; set; }
        public string? Category { get; set; }
        public string? ExternalFoodId { get; set; }
        public ICollection<DietFood> DietFoods { get; set; }
        public NutritionInfo? NutritionInfo { get; set; }
    }
}
