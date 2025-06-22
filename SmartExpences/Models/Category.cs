using System.ComponentModel.DataAnnotations;

namespace SmartExpenses.Models
{
    public class Category : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
