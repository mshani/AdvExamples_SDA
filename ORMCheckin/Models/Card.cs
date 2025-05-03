using System.ComponentModel.DataAnnotations;

namespace ORMCheckin.Models
{
    internal class Card
    {
        [Key]
        public int Id { get; set; }
        [StringLength(5)]
        public string Code { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public DateTime? IssuedDate { get; set; }
        public DateTime? DeactivationDate { get; set; } = null;
        public IEnumerable<UserCheckin> UserCheckins { get; set; }
    }
}
