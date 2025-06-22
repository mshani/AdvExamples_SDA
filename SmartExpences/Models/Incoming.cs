using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartExpenses.Models
{
    public class Incoming : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }
        [Required]
        [MaxLength(500)]
        public string? Description { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
