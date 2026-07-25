namespace NutriPlanner.Dtos
{
    public class NutritionInfoDto
    {
        public int FoodId { get; set; }
        public string? ExternalFoodId { get; set; }
        public DateTime LastUpdated { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
    }
}
