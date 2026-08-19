namespace NutriPlanner.Dtos
{
    public class LoginResponseDto
    {
        public required string Email { get; set; }
        public required string Token { get; set; }
        public int? DietId { get; set; }
    }
}