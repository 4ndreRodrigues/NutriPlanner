namespace NutriPlanner.Models
{
    public class DietFood
    {
        public int DietId { get; set; }
        public Diet Diet { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}
