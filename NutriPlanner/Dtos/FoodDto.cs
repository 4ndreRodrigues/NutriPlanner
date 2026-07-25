namespace NutriPlanner.Dtos
{
    public class FoodDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Category { get; set; }
        public string? ExternalFoodId { get; set; }
    }
}
