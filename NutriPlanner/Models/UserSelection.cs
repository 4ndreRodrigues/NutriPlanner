namespace NutriPlanner.Models
{
    public class UserSelection
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public DateTime AddedAt { get; set; }

    }
}
