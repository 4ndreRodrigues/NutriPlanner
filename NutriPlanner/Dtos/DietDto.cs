namespace NutriPlanner.Dtos
{
    public class DietDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}