namespace NutriPlanner.Models
{
    public class UserHealthCondition
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int HealthConditionId { get; set; }
        public HealthCondition HealthCondition { get; set; }
    }
}
