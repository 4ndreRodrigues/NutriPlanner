namespace NutriPlanner.Dtos
{
    public class UserFoodDto
    {
        public int Id { get; set; }
        public required int FoodId { get; set; }
        public string FoodName { get; set; }
        public DateTime AddedAt { get; set; }
    }
}