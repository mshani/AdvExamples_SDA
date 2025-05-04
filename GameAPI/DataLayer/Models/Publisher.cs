using System.ComponentModel.DataAnnotations;

namespace GameAPI.DataLayer.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(500)]
        public string? Address { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Phone { get; set; }

        public List<VideoGame>? VideoGames { get; set; }
    }
}
