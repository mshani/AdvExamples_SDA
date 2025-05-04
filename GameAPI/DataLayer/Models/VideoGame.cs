using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameAPI.DataLayer.Models
{
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        public int Size { get; set; }

        [MaxLength(100)]
        public string? Category { get; set; }

        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }

        [ForeignKey(nameof(Publisher))]
        public int? PublisherId { get; set; }

        public Publisher? Publisher { get; set; }
    }
}
