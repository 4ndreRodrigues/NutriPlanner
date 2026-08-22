using System.ComponentModel.DataAnnotations;

namespace NutriPlanner.Models
{
    public class HealthCondition
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<HealthConditionFood> HealthConditionFoods { get; set; }
    }
}
