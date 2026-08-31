namespace NutriPlanner.Dtos
{
    public class RegisterDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required DateTime BirthDate { get; set; }
    }
}