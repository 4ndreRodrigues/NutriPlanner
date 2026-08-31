namespace NutriPlanner.Dtos
{
    public class SafeFoodDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Category { get; set; }
        public required string Severity { get; set; } // "Safe", "Moderate", "Avoid"
        public string? Reason { get; set; }
    }
}