using NutriPlanner.Models;

namespace NutriPlanner.Dtos
{
    public class HealthConditionFoodDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? SearchTerm { get; set; }
        public string? Category { get; set; }
        public string? ExternalFoodId { get; set; }
        public FoodSeverity? Severity { get; set; }
    }
}