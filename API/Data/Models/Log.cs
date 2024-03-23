using System.ComponentModel.DataAnnotations;

namespace API.Data.Models
{
    public class Log
    {
        [Key]
        public int ID { get; set; }

        public int CardID { get; set; }

        [Required]
        [MaxLength(50)]
        public string ActionType { get; set; }

        public string ActionDetails { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public Card Card { get; set; }
    }
}
