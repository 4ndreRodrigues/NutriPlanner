namespace NutriPlanner.Dtos
{
    public class UserProfileDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public int? DietId { get; set; }
        public string? DietName { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}