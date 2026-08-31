namespace NutriPlanner.Models
{
    public class NutritionInfo
    {
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public string? ExternalFoodId { get; set; }
        public DateTime LastUpdated { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; } 
        public double Fat { get; set; }
    }
}
