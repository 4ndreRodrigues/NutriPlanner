namespace NutriPlanner.Dtos
{
    public class UserProfileDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public int? DietId { get; set; }
        public string? DietName { get; set; }
    }
}