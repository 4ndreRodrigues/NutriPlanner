namespace NutriPlanner.Dtos
{
    public class UserHealthConditionDto
    {
        public int? Id { get; set; }
        public required int HealthConditionId { get; set; }
        public string HealthConditionName { get; set; }
    }
}