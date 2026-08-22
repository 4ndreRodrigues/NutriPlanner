

namespace NutriPlanner.Models
{
    public class HealthConditionFood
    {
        public int HealthConditionId { get; set; }
        public HealthCondition HealthCondition { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public FoodSeverity Severity { get; set; }  // "Moderate" ou "Avoid"
    }
}
