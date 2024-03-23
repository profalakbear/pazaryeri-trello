using System.ComponentModel.DataAnnotations;

namespace API.Data.Models
{
    public class Card
    {
        [Key]
        public int ID { get; set; }

        public int ListID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public ListItem List { get; set; }

        public ICollection<Log> Logs { get; set; }
    }
}
