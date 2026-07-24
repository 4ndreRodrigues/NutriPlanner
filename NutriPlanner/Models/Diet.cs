using System.ComponentModel.DataAnnotations;

namespace NutriPlanner.Models
{
    public class Diet
    {
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public ICollection<DietFood> DietFoods { get; set; }
    }
}
