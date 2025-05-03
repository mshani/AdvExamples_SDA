using ORMCheckin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ORMCheckin.Models
{
    internal class UserCheckin
    {
        [Key]
        public int Id { get; set; }
        public int CardId { get; set; }
        [ForeignKey("CardId")]
        public Card Card { get; set; }
        [Required]
        public DateTime? Timestamp { get; set; }
        [Required]
        [StringLength(50)]
        public string Action { get; set; }
    }
}

//Student
//public int? DormitoryId { get; set; }
//[ForeignKey("DormitoryId")]
//public Dormitory Dormitory { get; set; }

//Dormitory
//public IEnumerable<Student> Students { get; set; }

//Ti shtoni nje studenti dhomen e tij duke kontrolluar maxCapacity