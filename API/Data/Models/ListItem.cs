using System.ComponentModel.DataAnnotations;

namespace API.Data.Models
{
    public class ListItem
    {
        [Key]
        public int ID { get; set; }

        public int UserID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public User User { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
